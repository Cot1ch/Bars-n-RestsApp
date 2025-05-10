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
        private bool isPasswordEntryVisible = true;
        public EntryAccount()
        {
            InitializeComponent();
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            string login = richTextBoxEntryLogin.Text.Trim();
            string password = textBoxEntryPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.username == login);

                    if (user == null)
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password_hash);

                        if (!isPasswordValid)
                        {
                            MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Invalid salt version"))
                        {
                            string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                            user.password_hash = newHashedPassword;
                            db.SaveChanges();
                        }
                        else
                        {
                            throw; 
                        }
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
            this.Close();
        }


        private void buttonBFEA_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void EntryAccount_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxShowEntryPassword_Click(object sender, EventArgs e)
        {
            var textBoxEntryPassword = this.Controls["textBoxEntryPassword"] as TextBox;
            if (textBoxEntryPassword != null)
            {
                if (isPasswordEntryVisible)
                {
                    textBoxEntryPassword.UseSystemPasswordChar = true;
                    pictureBoxShowEntryPassword.BackgroundImage = Properties.Resources.visible_password_security_protect_icon; 
                }
                else
                {
                    textBoxEntryPassword.UseSystemPasswordChar = false;
                    pictureBoxShowEntryPassword.BackgroundImage = Properties.Resources.eye_password_see_view_icon; 
                }

                isPasswordEntryVisible = !isPasswordEntryVisible;
            }
        }
    }
}
