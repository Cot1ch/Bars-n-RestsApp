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
    /// <summary>
    /// Форма входа в аккаунт
    /// </summary>
    public partial class EntryAccount : Form
    {
        /// <summary>
        /// Переменная для работы "глазика"
        /// </summary>
        private bool isPasswordEntryVisible = true;
        public EntryAccount()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод для поиска пользователя по логину 
        /// </summary>
        private User GetUserByUsername(AppDbContext db, string username)
        {
            foreach (var user in db.Users)
            {
                if (user.username == username)
                {
                    return user;
                }
            }
            return null;
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            var login = richTextBoxEntryLogin.Text.Trim();
            var password = textBoxEntryPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var user = GetUserByUsername(db, login);

                    if (user == null)
                    {
                        MessageBox.Show("Такого пользователя не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password_hash);

                    if (!isPasswordValid)
                    {
                        MessageBox.Show("Пароль неверный.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Вход выполнен успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); 
                    new MainForm(user.user_Id).Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonBFEA_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void pictureBoxShowEntryPassword_Click(object sender, EventArgs e)
        {
            var textBoxEntryPassword = this.Controls["textBoxEntryPassword"] as TextBox;
            if (textBoxEntryPassword != null)
            {
                if (isPasswordEntryVisible)
                {
                    textBoxEntryPassword.UseSystemPasswordChar = false;
                    pictureBoxShowEntryPassword.BackgroundImage = Properties.Resources.visible_password_security_protect_icon; 
                }
                else
                {
                    textBoxEntryPassword.UseSystemPasswordChar = true;
                    pictureBoxShowEntryPassword.BackgroundImage = Properties.Resources.eye_password_see_view_icon; 
                }

                isPasswordEntryVisible = !isPasswordEntryVisible;
            }
        }
    }
}
