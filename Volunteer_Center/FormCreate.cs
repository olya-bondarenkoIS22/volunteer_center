using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Volunteer_Center.models;

namespace Volunteer_Center
{
    public partial class FormCreate : Form
    {
        private TextBox txtName;
        private ComboBox cmbCategory;
        private DateTimePicker dtpDate;
        private TextBox txtPlace;
        private NumericUpDown numVolunteers;
        private ComboBox cmbStatus;
        private Label lblError;

        public FormCreate()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Get controls from the form
            txtName = this.Controls.Find("txtName", true).FirstOrDefault() as TextBox;
            cmbCategory = this.Controls.Find("cmbCategory", true).FirstOrDefault() as ComboBox;
            dtpDate = this.Controls.Find("dtpDate", true).FirstOrDefault() as DateTimePicker;
            txtPlace = this.Controls.Find("txtPlace", true).FirstOrDefault() as TextBox;
            numVolunteers = this.Controls.Find("numVolunteers", true).FirstOrDefault() as NumericUpDown;
            cmbStatus = this.Controls.Find("cmbStatus", true).FirstOrDefault() as ComboBox;
            lblError = this.Controls.Find("lblError", true).FirstOrDefault() as Label;
        }

        private void FormCreate_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadStatuses();
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

                    if (cmbCategory.Items.Count > 0)
                        cmbCategory.SelectedIndex = 0;
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

                    // Select "Запланировано" by default if exists
                    if (cmbStatus.Items.Count > 0)
                    {
                        for (int i = 0; i < cmbStatus.Items.Count; i++)
                        {
                            var status = cmbStatus.Items[i] as Status;
                            if (status != null && status.StatusName == "Запланировано")
                            {
                                cmbStatus.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка",
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
                lblError.Text = "Дата проведения не может быть в прошлом";
                dtpDate.Focus();
                return false;
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
                    var newEvent = new Event
                    {
                        Name = txtName.Text.Trim(),
                        IdCategory = (int)cmbCategory.SelectedValue,
                        Date = DateOnly.FromDateTime(dtpDate.Value),
                        Place = txtPlace.Text.Trim(),
                        VolunteersNeeded = (int)numVolunteers.Value,
                        IdStatus = (int)cmbStatus.SelectedValue
                    };

                    db.Events.Add(newEvent);
                    db.SaveChanges();

                    MessageBox.Show("Мероприятие успешно создано!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании мероприятия: {ex.Message}", "Ошибка",
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