namespace Volunteer_Center
{
    partial class FormCreate
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Form settings
            this.Text = "Создание нового мероприятия";
            this.Size = new System.Drawing.Size(600, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Main Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            mainPanel.BackColor = Color.White;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "СОЗДАНИЕ НОВОГО МЕРОПРИЯТИЯ";
            lblTitle.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(76, 175, 80);
            lblTitle.Size = new Size(540, 40);
            lblTitle.Location = new Point(10, 10);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Event Name
            Label lblName = new Label();
            lblName.Text = "Название мероприятия:*";
            lblName.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblName.Size = new Size(200, 30);
            lblName.Location = new Point(10, 70);

            TextBox txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.Size = new Size(320, 30);
            txtName.Location = new Point(220, 70);
            txtName.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            txtName.BackColor = Color.White;

            // Category
            Label lblCategory = new Label();
            lblCategory.Text = "Категория:*";
            lblCategory.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblCategory.Size = new Size(200, 30);
            lblCategory.Location = new Point(10, 115);

            ComboBox cmbCategory = new ComboBox();
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(320, 30);
            cmbCategory.Location = new Point(220, 115);
            cmbCategory.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            // Date
            Label lblDate = new Label();
            lblDate.Text = "Дата проведения:*";
            lblDate.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblDate.Size = new Size(200, 30);
            lblDate.Location = new Point(10, 160);

            DateTimePicker dtpDate = new DateTimePicker();
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(320, 30);
            dtpDate.Location = new Point(220, 160);
            dtpDate.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.MinDate = DateTime.Today;

            // Place
            Label lblPlace = new Label();
            lblPlace.Text = "Место проведения:*";
            lblPlace.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblPlace.Size = new Size(200, 30);
            lblPlace.Location = new Point(10, 205);

            TextBox txtPlace = new TextBox();
            txtPlace.Name = "txtPlace";
            txtPlace.Size = new Size(320, 30);
            txtPlace.Location = new Point(220, 205);
            txtPlace.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            txtPlace.BackColor = Color.White;

            // Volunteers Needed
            Label lblVolunteersNeeded = new Label();
            lblVolunteersNeeded.Text = "Необходимо волонтеров:*";
            lblVolunteersNeeded.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblVolunteersNeeded.Size = new Size(200, 30);
            lblVolunteersNeeded.Location = new Point(10, 250);

            NumericUpDown numVolunteers = new NumericUpDown();
            numVolunteers.Name = "numVolunteers";
            numVolunteers.Size = new Size(320, 30);
            numVolunteers.Location = new Point(220, 250);
            numVolunteers.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            numVolunteers.Minimum = 1;
            numVolunteers.Maximum = 1000;
            numVolunteers.Value = 10;

            // Status
            Label lblStatus = new Label();
            lblStatus.Text = "Статус:*";
            lblStatus.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblStatus.Size = new Size(200, 30);
            lblStatus.Location = new Point(10, 295);

            ComboBox cmbStatus = new ComboBox();
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(320, 30);
            cmbStatus.Location = new Point(220, 295);
            cmbStatus.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            // Buttons Panel
            Panel buttonPanel = new Panel();
            buttonPanel.Size = new Size(540, 60);
            buttonPanel.Location = new Point(10, 350);
            buttonPanel.BackColor = Color.White;

            Button btnSave = new Button();
            btnSave.Name = "btnSave";
            btnSave.Text = "Сохранить";
            btnSave.Size = new Size(200, 40);
            btnSave.Location = new Point(70, 10);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;

            Button btnCancel = new Button();
            btnCancel.Name = "btnCancel";
            btnCancel.Text = "Отмена";
            btnCancel.Size = new Size(200, 40);
            btnCancel.Location = new Point(280, 10);
            btnCancel.BackColor = Color.FromArgb(220, 53, 69);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnCancel.Cursor = Cursors.Hand;

            buttonPanel.Controls.AddRange(new Control[] { btnSave, btnCancel });

            // Required fields note
            Label lblNote = new Label();
            lblNote.Text = "* - поля, обязательные для заполнения";
            lblNote.Font = new Font("Times New Roman", 10, FontStyle.Italic);
            lblNote.ForeColor = Color.Gray;
            lblNote.Size = new Size(540, 25);
            lblNote.Location = new Point(10, 420);
            lblNote.TextAlign = ContentAlignment.MiddleCenter;

            // Error Label
            Label lblError = new Label();
            lblError.Name = "lblError";
            lblError.Text = "";
            lblError.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            lblError.ForeColor = Color.Red;
            lblError.Size = new Size(540, 30);
            lblError.Location = new Point(10, 450);
            lblError.TextAlign = ContentAlignment.MiddleCenter;

            mainPanel.Controls.AddRange(new Control[] {
                lblTitle,
                lblName, txtName,
                lblCategory, cmbCategory,
                lblDate, dtpDate,
                lblPlace, txtPlace,
                lblVolunteersNeeded, numVolunteers,
                lblStatus, cmbStatus,
                buttonPanel,
                lblNote,
                lblError
            });

            this.Controls.Add(mainPanel);

            // Store controls for access in code
            this.Tag = new { txtName, cmbCategory, dtpDate, txtPlace, numVolunteers, cmbStatus, lblError };

            // Attach event handlers
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            // Load data
            this.Load += FormCreate_Load;
        }

    }
}