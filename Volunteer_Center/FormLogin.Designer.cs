namespace Volunteer_Center
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            label2 = new Label();
            buttonLogin = new Button();
            buttonGuest = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(203, 38);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 186);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 254);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 22);
            label1.TabIndex = 1;
            label1.Text = "Логин:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(146, 279);
            textBoxLogin.Margin = new Padding(4, 3, 4, 3);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(302, 30);
            textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(146, 354);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(302, 30);
            textBoxPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 329);
            label2.Name = "label2";
            label2.Size = new Size(78, 22);
            label2.TabIndex = 4;
            label2.Text = "Пароль:";
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(76, 175, 80);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Location = new Point(300, 417);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(245, 55);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonGuest
            // 
            buttonGuest.BackColor = Color.Honeydew;
            buttonGuest.FlatStyle = FlatStyle.Flat;
            buttonGuest.Location = new Point(49, 417);
            buttonGuest.Name = "buttonGuest";
            buttonGuest.Size = new Size(245, 55);
            buttonGuest.TabIndex = 6;
            buttonGuest.Text = "Войти как гость";
            buttonGuest.UseVisualStyleBackColor = false;
            buttonGuest.Click += buttonGuest_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(594, 502);
            Controls.Add(buttonGuest);
            Controls.Add(buttonLogin);
            Controls.Add(label2);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormLogin";
            Text = "Волонтерский центр";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label label2;
        private Button buttonLogin;
        private Button buttonGuest;
    }
}
