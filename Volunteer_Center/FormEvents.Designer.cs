namespace Volunteer_Center
{
    partial class FormEvents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEvents));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            buttonReturn = new Button();
            labelFullName = new Label();
            pictureBox1 = new PictureBox();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonCreate = new Button();
            buttonVolunteerRegistration = new Button();
            dataGridViewEvent = new DataGridView();
            panel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvent).BeginInit();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(76, 175, 80);
            panel1.Controls.Add(buttonReturn);
            panel1.Controls.Add(labelFullName);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(14, 11, 14, 11);
            panel1.Size = new Size(1244, 121);
            panel1.TabIndex = 0;
            // 
            // buttonReturn
            // 
            buttonReturn.BackColor = Color.White;
            buttonReturn.FlatStyle = FlatStyle.Flat;
            buttonReturn.ForeColor = Color.FromArgb(76, 175, 80);
            buttonReturn.Location = new Point(131, 60);
            buttonReturn.Margin = new Padding(4, 3, 4, 3);
            buttonReturn.Name = "buttonReturn";
            buttonReturn.Size = new Size(151, 50);
            buttonReturn.TabIndex = 2;
            buttonReturn.Text = "Выйти";
            buttonReturn.UseVisualStyleBackColor = false;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.ForeColor = Color.White;
            labelFullName.Location = new Point(131, 25);
            labelFullName.Margin = new Padding(4, 0, 4, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(60, 22);
            labelFullName.TabIndex = 1;
            labelFullName.Text = "label1";
            labelFullName.TextAlign = ContentAlignment.BottomRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 11);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(76, 175, 80);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(10, 196);
            buttonDelete.Margin = new Padding(10);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(230, 41);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.FromArgb(76, 175, 80);
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(10, 74);
            buttonUpdate.Margin = new Padding(10);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(230, 41);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = Color.FromArgb(76, 175, 80);
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.ForeColor = Color.White;
            buttonCreate.Location = new Point(10, 135);
            buttonCreate.Margin = new Padding(10);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(230, 41);
            buttonCreate.TabIndex = 4;
            buttonCreate.Text = "Добавить";
            buttonCreate.UseVisualStyleBackColor = false;
            // 
            // buttonVolunteerRegistration
            // 
            buttonVolunteerRegistration.BackColor = Color.FromArgb(76, 175, 80);
            buttonVolunteerRegistration.FlatStyle = FlatStyle.Flat;
            buttonVolunteerRegistration.ForeColor = Color.White;
            buttonVolunteerRegistration.Location = new Point(10, 13);
            buttonVolunteerRegistration.Margin = new Padding(10);
            buttonVolunteerRegistration.Name = "buttonVolunteerRegistration";
            buttonVolunteerRegistration.Size = new Size(230, 41);
            buttonVolunteerRegistration.TabIndex = 3;
            buttonVolunteerRegistration.Text = "Регистрация волонтеров";
            buttonVolunteerRegistration.UseVisualStyleBackColor = false;
            buttonVolunteerRegistration.Click += buttonVolunteerRegistration_Click;
            // 
            // dataGridViewEvent
            // 
            dataGridViewEvent.BackgroundColor = Color.White;
            dataGridViewEvent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Azure;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewEvent.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewEvent.Location = new Point(0, 121);
            dataGridViewEvent.Name = "dataGridViewEvent";
            dataGridViewEvent.RowHeadersWidth = 51;
            dataGridViewEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEvent.Size = new Size(991, 724);
            dataGridViewEvent.TabIndex = 1;
            // 
            // panel
            // 
            panel.BackColor = Color.Honeydew;
            panel.Controls.Add(buttonVolunteerRegistration);
            panel.Controls.Add(buttonDelete);
            panel.Controls.Add(buttonUpdate);
            panel.Controls.Add(buttonCreate);
            panel.Dock = DockStyle.Right;
            panel.Location = new Point(994, 121);
            panel.Name = "panel";
            panel.Size = new Size(250, 724);
            panel.TabIndex = 2;
            // 
            // FormEvents
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1244, 845);
            Controls.Add(panel);
            Controls.Add(dataGridViewEvent);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormEvents";
            Text = "Волонтерский центр";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvent).EndInit();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonReturn;
        private Label labelFullName;
        private PictureBox pictureBox1;
        private Button buttonVolunteerRegistration;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonCreate;
        private DataGridView dataGridViewEvent;
        private Panel panel;
    }
}