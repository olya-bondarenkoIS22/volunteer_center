using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Volunteer_Center.models;

namespace Volunteer_Center
{
    public partial class FormEdit : Form
    {
        private TextBox txtId;
        private TextBox txtName;
        private ComboBox cmbCategory;
        private DateTimePicker dtpDate;
        private TextBox txtPlace;
        private NumericUpDown numVolunteers;
        private ComboBox cmbStatus;
        private Label lblWarning;
        private Label lblError;

        private Event currentEvent;

        public FormEdit(Event eventToEdit)
        {
            InitializeComponent();
            currentEvent = eventToEdit;
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Get controls from the form
            txtId = this.Controls.Find("txtId", true).FirstOrDefault() as TextBox;
            txtName = this.Controls.Find("txtName", true).FirstOrDefault() as TextBox;
            cmbCategory = this.Controls.Find("cmbCategory", true).FirstOrDefault() as ComboBox;
            dtpDate = this.Controls.Find("dtpDate", true).FirstOrDefault() as DateTimePicker;
            txtPlace = this.Controls.Find("txtPlace", true).FirstOrDefault() as TextBox;
            numVolunteers = this.Controls.Find("numVolunteers", true).FirstOrDefault() as NumericUpDown;
            cmbStatus = this.Controls.Find("cmbStatus", true).FirstOrDefault() as ComboBox;
            lblWarning = this.Controls.Find("lblWarning", true).FirstOrDefault() as Label;
            lblError = this.Controls.Find("lblError", true).FirstOrDefault() as Label;
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadStatuses();
            LoadEventData();
        }

        private void LoadCategories()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var categories = db.Categories.ToList();
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "Id";
                    cmbCategory.DataSource = categories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatuses()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var statuses = db.Statuses.ToList();
                    cmbStatus.DisplayMember = "StatusName";
                    cmbStatus.ValueMember = "Id";
                    cmbStatus.DataSource = statuses;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEventData()
        {
            if (currentEvent == null) return;

            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var eventData = db.Events
                        .Include(e => e.IdCategoryNavigation)
                        .Include(e => e.IdStatusNavigation)
                        .FirstOrDefault(e => e.Id == currentEvent.Id);

                    if (eventData != null)
                    {
                        txtId.Text = eventData.Id.ToString();
                        txtName.Text = eventData.Name;

                        // Set category
                        if (cmbCategory.Items.Count > 0)
                        {
                            cmbCategory.SelectedValue = eventData.IdCategory;
                        }

                        // Set date
                        if (eventData.Date.HasValue)
                        {
                            dtpDate.Value = new DateTime(eventData.Date.Value.Year,
                                eventData.Date.Value.Month,
                                eventData.Date.Value.Day);
                        }

                        txtPlace.Text = eventData.Place;
                        numVolunteers.Value = eventData.VolunteersNeeded ?? 0;

                        // Set status
                        if (cmbStatus.Items.Count > 0)
                        {
                            cmbStatus.SelectedValue = eventData.IdStatus;
                        }

                        // Show warning if event is completed
                        if (eventData.IdStatusNavigation?.StatusName == "Завершено")
                        {
                            lblWarning.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных мероприятия: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblError.Text = "Пожалуйста, введите название мероприятия";
                txtName.Focus();
                return false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                lblError.Text = "Пожалуйста, выберите категорию";
                cmbCategory.Focus();
                return false;
            }

            if (dtpDate.Value < DateTime.Today)
            {
                var status = cmbStatus.SelectedItem as Status;
                if (status?.StatusName != "Завершено")
                {
                    lblError.Text = "Дата проведения не может быть в прошлом (кроме завершенных мероприятий)";
                    dtpDate.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtPlace.Text))
            {
                lblError.Text = "Пожалуйста, укажите место проведения";
                txtPlace.Focus();
                return false;
            }

            if (numVolunteers.Value <= 0)
            {
                lblError.Text = "Количество волонтеров должно быть больше 0";
                numVolunteers.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                lblError.Text = "Пожалуйста, выберите статус";
                cmbStatus.Focus();
                return false;
            }

            lblError.Text = "";
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var eventToUpdate = db.Events.Find(currentEvent.Id);

                    if (eventToUpdate == null)
                    {
                        MessageBox.Show("Мероприятие не найдено в базе данных", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check if volunteers are already registered
                    var registrationsCount = db.VolunteerRegistrations
                        .Count(r => r.IdEvent == currentEvent.Id && r.IdRegistrationStatus == 1); // Status 1 = "Подтверждено"

                    if (registrationsCount > (int)numVolunteers.Value)
                    {
                        MessageBox.Show($"Невозможно уменьшить количество волонтеров до {numVolunteers.Value}, " +
                            $"так как уже зарегистрировано {registrationsCount} подтвержденных волонтеров",
                            "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update event data
                    eventToUpdate.Name = txtName.Text.Trim();
                    eventToUpdate.IdCategory = (int)cmbCategory.SelectedValue;
                    eventToUpdate.Date = DateOnly.FromDateTime(dtpDate.Value);
                    eventToUpdate.Place = txtPlace.Text.Trim();
                    eventToUpdate.VolunteersNeeded = (int)numVolunteers.Value;
                    eventToUpdate.IdStatus = (int)cmbStatus.SelectedValue;

                    db.SaveChanges();

                    MessageBox.Show("Мероприятие успешно обновлено!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении мероприятия: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}