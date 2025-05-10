using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecsApp.forms
{
    public partial class EntryAccount : Form
    {
        private bool isPasswordEntryVisible = true; // Флаг для отслеживания видимости пароля
        public EntryAccount()
        {
            InitializeComponent();
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            string login = richTextBoxEntryLogin.Text.Trim();
            string password = textBoxEntryPassword.Text.Trim();

            // Проверяем, заполнены ли все поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // Ищем пользователя по логину
                    var user = db.Users.FirstOrDefault(u => u.username == login);

                    if (user == null)
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Сравниваем введенный пароль с хэшированным паролем
                    if (password != user.password_hash)
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Если данные верны, разрешаем вход
                    MessageBox.Show("Вход выполнен успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Перейдите к основной форме приложения
                    new MainForm(user.user_Id).Show(); // Открыть главную форму
                    this.Hide(); // Скрыть форму входа
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void buttonEntry_Paint(object sender, PaintEventArgs e)
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

        private void buttonBFEA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBFEA_Paint(object sender, PaintEventArgs e)
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

        private void EntryAccount_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxShowEntryPassword_Click(object sender, EventArgs e)
        {
            // Переключаем видимость пароля
            var textBoxEntryPassword = this.Controls["textBoxEntryPassword"] as TextBox;
            if (textBoxEntryPassword != null)
            {
                if (isPasswordEntryVisible)
                {
                    // Скрыть пароль
                    textBoxEntryPassword.UseSystemPasswordChar = true;
                    pictureBoxShowEntryPassword.BackgroundImage = Properties.Resources.visible_password_security_protect_icon; // Изображение открытого глазика
                }
                else
                {
                    // Показать пароль
                    textBoxEntryPassword.UseSystemPasswordChar = false;
                    pictureBoxShowEntryPassword.BackgroundImage = Properties.Resources.eye_password_see_view_icon; // Изображение закрытого глазика
                }

                // Инвертируем флаг
                isPasswordEntryVisible = !isPasswordEntryVisible;
            }
        }
    }
}
