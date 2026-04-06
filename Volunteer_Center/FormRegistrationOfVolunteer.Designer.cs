namespace Volunteer_Center
{
    partial class FormRegistrationOfVolunteer
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrationOfVolunteer));

            // Form settings
            this.Text = "Регистрация волонтера на мероприятие";
            this.Size = new Size(600, 500);
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

            // Event Info GroupBox
            GroupBox groupEventInfo = new GroupBox();
            groupEventInfo.Text = "Информация о мероприятии";
            groupEventInfo.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            groupEventInfo.ForeColor = Color.FromArgb(76, 175, 80);
            groupEventInfo.Size = new Size(540, 200);
            groupEventInfo.Location = new Point(10, 10);
            groupEventInfo.Padding = new Padding(10);

            Label lblEventName = new Label();
            lblEventName.Text = "Название мероприятия:";
            lblEventName.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lblEventName.Size = new Size(180, 30);
            lblEventName.Location = new Point(15, 35);

            Label lblEventNameValue = new Label();
            lblEventNameValue.Name = "lblEventNameValue";
            lblEventNameValue.Text = "";
            lblEventNameValue.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblEventNameValue.ForeColor = Color.FromArgb(76, 175, 80);
            lblEventNameValue.Size = new Size(300, 30);
            lblEventNameValue.Location = new Point(210, 35);

            Label lblEventDate = new Label();
            lblEventDate.Text = "Дата проведения:";
            lblEventDate.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lblEventDate.Size = new Size(180, 30);
            lblEventDate.Location = new Point(15, 75);

            Label lblEventDateValue = new Label();
            lblEventDateValue.Name = "lblEventDateValue";
            lblEventDateValue.Text = "";
            lblEventDateValue.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblEventDateValue.Size = new Size(300, 30);
            lblEventDateValue.Location = new Point(210, 75);

            Label lblEventPlace = new Label();
            lblEventPlace.Text = "Место проведения:";
            lblEventPlace.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lblEventPlace.Size = new Size(180, 30);
            lblEventPlace.Location = new Point(15, 115);

            Label lblEventPlaceValue = new Label();
            lblEventPlaceValue.Name = "lblEventPlaceValue";
            lblEventPlaceValue.Text = "";
            lblEventPlaceValue.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblEventPlaceValue.Size = new Size(300, 60);
            lblEventPlaceValue.Location = new Point(210, 115);

            Label lblFreeSpots = new Label();
            lblFreeSpots.Text = "Свободных мест:";
            lblFreeSpots.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lblFreeSpots.Size = new Size(180, 30);
            lblFreeSpots.Location = new Point(15, 155);

            Label lblFreeSpotsValue = new Label();
            lblFreeSpotsValue.Name = "lblFreeSpotsValue";
            lblFreeSpotsValue.Text = "";
            lblFreeSpotsValue.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblFreeSpotsValue.ForeColor = Color.FromArgb(76, 175, 80);
            lblFreeSpotsValue.Size = new Size(300, 30);
            lblFreeSpotsValue.Location = new Point(210, 155);

            groupEventInfo.Controls.AddRange(new Control[] {
                lblEventName, lblEventNameValue,
                lblEventDate, lblEventDateValue,
                lblEventPlace, lblEventPlaceValue,
                lblFreeSpots, lblFreeSpotsValue
            });

            // Volunteer Info GroupBox
            GroupBox groupVolunteerInfo = new GroupBox();
            groupVolunteerInfo.Text = "Информация о волонтере";
            groupVolunteerInfo.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            groupVolunteerInfo.ForeColor = Color.FromArgb(76, 175, 80);
            groupVolunteerInfo.Size = new Size(540, 130);
            groupVolunteerInfo.Location = new Point(10, 220);
            groupVolunteerInfo.Padding = new Padding(10);

            Label lblVolunteerName = new Label();
            lblVolunteerName.Text = "ФИО волонтера:";
            lblVolunteerName.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lblVolunteerName.Size = new Size(180, 30);
            lblVolunteerName.Location = new Point(15, 35);

            Label lblVolunteerNameValue = new Label();
            lblVolunteerNameValue.Name = "lblVolunteerNameValue";
            lblVolunteerNameValue.Text = "";
            lblVolunteerNameValue.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblVolunteerNameValue.ForeColor = Color.FromArgb(76, 175, 80);
            lblVolunteerNameValue.Size = new Size(300, 30);
            lblVolunteerNameValue.Location = new Point(210, 35);

            Label lblRegistrationDate = new Label();
            lblRegistrationDate.Text = "Дата регистрации:";
            lblRegistrationDate.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lblRegistrationDate.Size = new Size(180, 30);
            lblRegistrationDate.Location = new Point(15, 75);

            Label lblRegistrationDateValue = new Label();
            lblRegistrationDateValue.Name = "lblRegistrationDateValue";
            lblRegistrationDateValue.Text = "";
            lblRegistrationDateValue.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lblRegistrationDateValue.Size = new Size(300, 30);
            lblRegistrationDateValue.Location = new Point(210, 75);

            groupVolunteerInfo.Controls.AddRange(new Control[] {
                lblVolunteerName, lblVolunteerNameValue,
                lblRegistrationDate, lblRegistrationDateValue
            });

            // Buttons Panel
            Panel buttonPanel = new Panel();
            buttonPanel.Size = new Size(540, 60);
            buttonPanel.Location = new Point(10, 360);
            buttonPanel.BackColor = Color.White;

            Button btnConfirm = new Button();
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Text = "Подтвердить регистрацию";
            btnConfirm.Size = new Size(200, 40);
            btnConfirm.Location = new Point(70, 10);
            btnConfirm.BackColor = Color.FromArgb(76, 175, 80);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            btnConfirm.Cursor = Cursors.Hand;

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

            buttonPanel.Controls.AddRange(new Control[] { btnConfirm, btnCancel });

            // Status Label
            Label lblStatus = new Label();
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "";
            lblStatus.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            lblStatus.ForeColor = Color.FromArgb(76, 175, 80);
            lblStatus.Size = new Size(540, 30);
            lblStatus.Location = new Point(10, 425);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            mainPanel.Controls.AddRange(new Control[] {
                groupEventInfo,
                groupVolunteerInfo,
                buttonPanel,
                lblStatus
            });

            this.Controls.Add(mainPanel);

            // Attach event handlers
            btnConfirm.Click += BtnConfirm_Click;
            btnCancel.Click += BtnCancel_Click;
        }
    }
}