using Microsoft.EntityFrameworkCore;

namespace Volunteer_Center
{
    public partial class FormLogin : Form
    {
        public models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormLogin()
        {
            InitializeComponent();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) ||
                string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var db = new VolunteerCenterContext())
            {
                var user = db.Users
                    .Where(w => w.Login == textBoxLogin.Text && w.Password == textBoxPassword.Text)
                    .Include(u => u.IdRoleNavigation)
                    .FirstOrDefault();
                if (user != null)
                {
                    CurrentUser = user;
                    IsGuest = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            IsGuest = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
