using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RecsApp.forms
{
    public partial class CreateAccount : Form
    {
        private Guid userId;
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string name = richTextBoxCreateName.Text.Trim();
            string login = richTextBoxCreateLogin.Text.Trim();
            string password = richTextBoxCreatePassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    if (db.Users.Any(u => u.username == login))
                    {
                        MessageBox.Show("Логин уже занят. Пожалуйста, выберите другой логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newUser = new User
                    {
                        user_Id = Guid.NewGuid(),
                        name = name,
                        username = login,
                        password_hash = password
                    };
                    userId = newUser.user_Id;
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

                MessageBox.Show("Аккаунт успешно создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                richTextBoxCreateName.Clear();
                richTextBoxCreateLogin.Clear();
                richTextBoxCreatePassword.Clear();

                new MainForm(this.userId).Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 5;
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                button.Region = new Region(path);
            }
        }

        private void buttonBFCA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBFCA_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 5;
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                button.Region = new Region(path);
            }
        }
    }
}
