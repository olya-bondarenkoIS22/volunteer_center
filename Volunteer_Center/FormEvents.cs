using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Volunteer_Center.models;

namespace Volunteer_Center
{
    public partial class FormEvents : Form
    {
        public models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        private string currentUserRole;

        private string searchText = "";
        private string sortOrder = "asc";

        public FormEvents(models.User user, bool guest)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = guest;
            labelFullName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            ConfigureDataGridView();
            LoadRole();
            SetupUIBasedOnRole();
            LoadEvents();
            AttachEventHandlers();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewEvent.AutoGenerateColumns = false;
            dataGridViewEvent.RowHeadersVisible = false;
            dataGridViewEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEvent.AllowUserToAddRows = false;

            // Clear existing columns
            dataGridViewEvent.Columns.Clear();

            // Column 1: Event name and category
            var colInfoNameCategory = new DataGridViewTextBoxColumn();
            colInfoNameCategory.Name = "colInfoNameCategory";
            colInfoNameCategory.HeaderText = "Мероприятие и категория";
            colInfoNameCategory.FillWeight = 35;
            colInfoNameCategory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoNameCategory.DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            colInfoNameCategory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            colInfoNameCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Column 2: Date and place
            var colInfoDatePlace = new DataGridViewTextBoxColumn();
            colInfoDatePlace.Name = "colInfoDatePlace";
            colInfoDatePlace.HeaderText = "Дата и место";
            colInfoDatePlace.FillWeight = 25;
            colInfoDatePlace.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoDatePlace.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colInfoDatePlace.DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            colInfoDatePlace.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Column 3: Volunteers info
            var colInfoVolunteers = new DataGridViewTextBoxColumn();
            colInfoVolunteers.Name = "colInfoVolunteers";
            colInfoVolunteers.HeaderText = "Волонтеры";
            colInfoVolunteers.FillWeight = 25;
            colInfoVolunteers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoVolunteers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colInfoVolunteers.DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            colInfoVolunteers.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Column 4: Status
            var colInfoStatus = new DataGridViewTextBoxColumn();
            colInfoStatus.Name = "colInfoStatus";
            colInfoStatus.HeaderText = "Статус";
            colInfoStatus.FillWeight = 15;
            colInfoStatus.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colInfoStatus.DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            colInfoStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewEvent.Columns.AddRange(colInfoNameCategory, colInfoDatePlace, colInfoVolunteers, colInfoStatus);
            dataGridViewEvent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void LoadRole()
        {
            if (!IsGuest && CurrentUser?.IdRoleNavigation != null)
            {
                currentUserRole = CurrentUser.IdRoleNavigation.RoleName;
            }
            else
            {
                currentUserRole = "Гость";
            }
        }

        private void SetupUIBasedOnRole()
        {
            // Hide panel for guests and volunteers (they don't need the right panel)
            if (IsGuest || currentUserRole == "Волонтер")
            {
                panel.Visible = false;
                dataGridViewEvent.Dock = DockStyle.Fill;
            }
            else
            {
                panel.Visible = true;

                // For Coordinator and Administrator, show the registration button
                buttonVolunteerRegistration.Visible = true;

                if (currentUserRole == "Координатор")
                {
                    // Coordinator can create, update, and register volunteers
                    buttonCreate.Visible = true;
                    buttonUpdate.Visible = true;
                    buttonDelete.Visible = false; // Coordinator cannot delete
                }
                else if (currentUserRole == "Администратор")
                {
                    // Administrator can do everything
                    buttonCreate.Visible = true;
                    buttonUpdate.Visible = true;
                    buttonDelete.Visible = true;
                    buttonVolunteerRegistration.Visible = true;
                }
            }
        }

        private void AttachEventHandlers()
        {
            buttonReturn.Click += ButtonReturn_Click;
            buttonCreate.Click += ButtonCreate_Click;
            buttonUpdate.Click += ButtonUpdate_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonVolunteerRegistration.Click += buttonVolunteerRegistration_Click;
        }

        private void LoadEvents()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var events = db.Events
                        .Include(e => e.IdCategoryNavigation)
                        .Include(e => e.IdStatusNavigation)
                        .Include(e => e.VolunteerRegistrations)
                            .ThenInclude(vr => vr.IdRegistrationStatusNavigation)
                        .AsQueryable();

                    // Filter by search text if any
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        events = events.Where(e => e.Name.Contains(searchText) ||
                                                   e.IdCategoryNavigation.CategoryName.Contains(searchText));
                    }

                    // Sort events
                    if (sortOrder == "asc")
                        events = events.OrderBy(e => e.Date);
                    else
                        events = events.OrderByDescending(e => e.Date);

                    dataGridViewEvent.SuspendLayout();
                    dataGridViewEvent.Rows.Clear();

                    foreach (var even in events)
                    {
                        int rowIndex = dataGridViewEvent.Rows.Add();
                        var row = dataGridViewEvent.Rows[rowIndex];

                        row.Tag = even;

                        // Calculate confirmed registrations (status "Подтверждено")
                        int confirmedRegistrations = even.VolunteerRegistrations?
                            .Count(r => r.IdRegistrationStatusNavigation?.RegistrationStatusName == "Подтверждено") ?? 0;

                        int volunteersNeeded = even.VolunteersNeeded ?? 0;
                        int freeSpots = volunteersNeeded - confirmedRegistrations;
                        double percentage = volunteersNeeded > 0
                            ? (confirmedRegistrations / (double)volunteersNeeded) * 100
                            : 0;

                        row.Cells["colInfoNameCategory"].Value = FormatNameCategory(even);
                        row.Cells["colInfoDatePlace"].Value = FormatDatePlace(even);
                        row.Cells["colInfoVolunteers"].Value = FormatVolunteersInfo(even, confirmedRegistrations, freeSpots, percentage);
                        row.Cells["colInfoStatus"].Value = even.IdStatusNavigation?.StatusName ?? "Неизвестно";

                        // Apply row coloring based on status and availability
                        ApplyRowColor(row, even, freeSpots);
                    }

                    dataGridViewEvent.ResumeLayout();

                    // Update volunteer stats if user is volunteer
                    if (currentUserRole == "Волонтер" && !IsGuest)
                    {
                        UpdateVolunteerStats();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowColor(DataGridViewRow row, models.Event even, int freeSpots)
        {
            string status = even.IdStatusNavigation?.StatusName ?? "";

            if (status == "Отменено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFB6C1"); // Light pink
            }
            else if (status == "Завершено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0E0E0"); // Light gray
            }
            else if (status == "Запланировано" && freeSpots < 3 && freeSpots >= 0)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE5B4"); // Peach
            }
        }

        private string FormatDatePlace(models.Event even)
        {
            string dateStr = even.Date.HasValue ? even.Date.Value.ToString("dd.MM.yyyy") : "Дата не указана";
            return $"Дата: {dateStr}\nМесто: {even.Place ?? "Не указано"}";
        }

        private string FormatNameCategory(models.Event even)
        {
            return $"Название: {even.Name ?? "Без названия"}\nКатегория: {even.IdCategoryNavigation?.CategoryName ?? "Без категории"}";
        }

        private string FormatVolunteersInfo(models.Event even, int confirmedRegistrations, int freeSpots, double percentage)
        {
            int volunteersNeeded = even.VolunteersNeeded ?? 0;
            return $"Необходимо: {volunteersNeeded}\n" +
                   $"Подтверждено: {confirmedRegistrations}\n" +
                   $"Свободно мест: {freeSpots}\n" +
                   $"Набор: {percentage:F1}%";
        }

        private void UpdateVolunteerStats()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    // Get current volunteer's completed events
                    int completedEventsCount = db.VolunteerRegistrations
                        .Include(r => r.IdEventNavigation)
                            .ThenInclude(e => e.IdStatusNavigation)
                        .Include(r => r.IdRegistrationStatusNavigation)
                        .Count(r => r.IdUser == CurrentUser.Id &&
                                   r.IdRegistrationStatusNavigation.RegistrationStatusName == "Подтверждено" &&
                                   r.IdEventNavigation.IdStatusNavigation.StatusName == "Завершено");

                    // Create or update stats label on the main form
                    Label volunteerStatsLabel = null;
                    if (!this.Controls.ContainsKey("volunteerStatsLabel"))
                    {
                        volunteerStatsLabel = new Label();
                        volunteerStatsLabel.Name = "volunteerStatsLabel";
                        volunteerStatsLabel.Dock = DockStyle.Bottom;
                        volunteerStatsLabel.Height = 50;
                        volunteerStatsLabel.TextAlign = ContentAlignment.MiddleCenter;
                        volunteerStatsLabel.BackColor = Color.LightBlue;
                        volunteerStatsLabel.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                        this.Controls.Add(volunteerStatsLabel);
                        volunteerStatsLabel.BringToFront();
                    }
                    else
                    {
                        volunteerStatsLabel = this.Controls["volunteerStatsLabel"] as Label;
                    }

                    if (volunteerStatsLabel != null)
                    {
                        volunteerStatsLabel.Text = $"★ ВЫ УЧАСТВОВАЛИ В {completedEventsCount} ЗАВЕРШЕННЫХ МЕРОПРИЯТИЯХ ★";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики волонтера: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            var loginForm = new FormLogin();
            loginForm.Show();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            using (var createForm = new FormCreate())
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEvents(); // Refresh the events list
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvent.SelectedRows.Count > 0)
            {
                var selectedEvent = dataGridViewEvent.SelectedRows[0].Tag as models.Event;

                if (selectedEvent != null)
                {
                    using (var editForm = new FormEdit(selectedEvent))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadEvents(); // Refresh the events list
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите мероприятие для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvent.SelectedRows.Count > 0)
            {
                var selectedEvent = dataGridViewEvent.SelectedRows[0].Tag as models.Event;
                var result = MessageBox.Show($"Вы уверены, что хотите удалить мероприятие \"{selectedEvent?.Name}\"?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new VolunteerCenterContext())
                        {
                            var eventToDelete = db.Events.Find(selectedEvent.Id);
                            if (eventToDelete != null)
                            {
                                db.Events.Remove(eventToDelete);
                                db.SaveChanges();
                                MessageBox.Show("Мероприятие успешно удалено", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadEvents(); // Refresh data
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите мероприятие для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonVolunteerRegistration_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите мероприятие для регистрации", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedEvent = dataGridViewEvent.SelectedRows[0].Tag as models.Event;

            var registrationForm = new FormRegistrationOfVolunteer(CurrentUser, selectedEvent, IsGuest);
            registrationForm.ShowDialog();
            LoadEvents();
        }
    }
}