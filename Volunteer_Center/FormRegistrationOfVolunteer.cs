using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Volunteer_Center.models;

namespace Volunteer_Center
{
    public partial class FormRegistrationOfVolunteer : Form
    {
        private models.User currentUser;
        private models.Event selectedEvent;
        private bool isGuest;

        public FormRegistrationOfVolunteer(models.User user, models.Event eventItem, bool guest)
        {
            InitializeComponent();
            currentUser = user;
            selectedEvent = eventItem;
            isGuest = guest;

            LoadEventInfo();
            LoadVolunteerInfo();
        }

        private void LoadEventInfo()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var even = db.Events
                        .Include(e => e.IdCategoryNavigation)
                        .Include(e => e.IdStatusNavigation)
                        .Include(e => e.VolunteerRegistrations)
                            .ThenInclude(vr => vr.IdRegistrationStatusNavigation)
                        .FirstOrDefault(e => e.Id == selectedEvent.Id);

                    if (even != null)
                    {
                        // Find the label controls by name
                        var lblEventNameValue = Controls.Find("lblEventNameValue", true).FirstOrDefault() as Label;
                        var lblEventDateValue = Controls.Find("lblEventDateValue", true).FirstOrDefault() as Label;
                        var lblEventPlaceValue = Controls.Find("lblEventPlaceValue", true).FirstOrDefault() as Label;
                        var lblFreeSpotsValue = Controls.Find("lblFreeSpotsValue", true).FirstOrDefault() as Label;

                        if (lblEventNameValue != null)
                            lblEventNameValue.Text = even.Name ?? "Без названия";

                        if (lblEventDateValue != null)
                            lblEventDateValue.Text = even.Date.HasValue ? even.Date.Value.ToString("dd.MM.yyyy") : "Дата не указана";

                        if (lblEventPlaceValue != null)
                            lblEventPlaceValue.Text = even.Place ?? "Место не указано";

                        // Calculate free spots
                        int confirmedRegistrations = even.VolunteerRegistrations?
                            .Count(r => r.IdRegistrationStatusNavigation?.RegistrationStatusName == "Подтверждено") ?? 0;
                        int volunteersNeeded = even.VolunteersNeeded ?? 0;
                        int freeSpots = volunteersNeeded - confirmedRegistrations;

                        if (lblFreeSpotsValue != null)
                        {
                            lblFreeSpotsValue.Text = freeSpots.ToString();
                            if (freeSpots <= 0)
                            {
                                lblFreeSpotsValue.ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки информации о мероприятии: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVolunteerInfo()
        {
            try
            {
                var lblVolunteerNameValue = Controls.Find("lblVolunteerNameValue", true).FirstOrDefault() as Label;
                var lblRegistrationDateValue = Controls.Find("lblRegistrationDateValue", true).FirstOrDefault() as Label;

                if (lblVolunteerNameValue != null)
                {
                    lblVolunteerNameValue.Text = isGuest ? "Гость" : (currentUser?.FullName ?? "Неизвестно");
                }

                if (lblRegistrationDateValue != null)
                {
                    lblRegistrationDateValue.Text = DateTime.Now.ToString("dd.MM.yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки информации о волонтере: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (isGuest)
            {
                MessageBox.Show("Гости не могут регистрироваться на мероприятия. Пожалуйста, авторизуйтесь.", "Доступ запрещен",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    // Check if already registered
                    var existingRegistration = db.VolunteerRegistrations
                        .FirstOrDefault(r => r.IdEvent == selectedEvent.Id && r.IdUser == currentUser.Id);

                    if (existingRegistration != null)
                    {
                        MessageBox.Show("Вы уже зарегистрированы на это мероприятие!", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Check free spots
                    var even = db.Events
                        .Include(e => e.VolunteerRegistrations)
                        .FirstOrDefault(e => e.Id == selectedEvent.Id);

                    int confirmedRegistrations = even.VolunteerRegistrations?
                        .Count(r => r.IdRegistrationStatus == 1) ?? 0; // Status 1 = "Подтверждено"
                    int volunteersNeeded = even.VolunteersNeeded ?? 0;
                    int freeSpots = volunteersNeeded - confirmedRegistrations;

                    if (freeSpots <= 0)
                    {
                        MessageBox.Show("Извините, но все места на это мероприятие уже заняты!", "Мест нет",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Create new registration
                    var registration = new VolunteerRegistration
                    {
                        IdEvent = selectedEvent.Id,
                        IdUser = currentUser.Id,
                        RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
                        IdRegistrationStatus = 2 // Status 2 = "На рассмотрении"
                    };

                    db.VolunteerRegistrations.Add(registration);
                    db.SaveChanges();

                    var lblStatus = Controls.Find("lblStatus", true).FirstOrDefault() as Label;
                    if (lblStatus != null)
                    {
                        lblStatus.Text = "✓ Заявка успешно отправлена! Статус: На рассмотрении";
                        lblStatus.ForeColor = Color.Green;
                    }

                    // Disable confirm button to prevent double registration
                    var btnConfirm = Controls.Find("btnConfirm", true).FirstOrDefault() as Button;
                    if (btnConfirm != null)
                    {
                        btnConfirm.Enabled = false;
                    }

                    MessageBox.Show("Вы успешно зарегистрированы на мероприятие!\nСтатус заявки: На рассмотрении", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}