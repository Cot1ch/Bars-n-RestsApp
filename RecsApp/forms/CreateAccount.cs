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
        private bool isPasswordCreateVisible = true; // Флаг для отслеживания видимости пароля
        private bool isPasswordConfirmVisible = true;

        public CreateAccount()
        {
            InitializeComponent();
        }



        private void pbShowPassword_Click(object sender, EventArgs e)
        {
            // Переключаем видимость пароля
            var textBoxCreatePassword = this.Controls["textBoxCreatePassword"] as TextBox;
            if (textBoxCreatePassword != null)
            {
                if (isPasswordCreateVisible)
                {
                    // Скрыть пароль
                    textBoxCreatePassword.UseSystemPasswordChar = true;
                    pbShowPassword.BackgroundImage = Properties.Resources.visible_password_security_protect_icon; // Изображение открытого глазика
                }
                else
                {
                    // Показать пароль
                    textBoxCreatePassword.UseSystemPasswordChar = false;
                    pbShowPassword.BackgroundImage = Properties.Resources.eye_password_see_view_icon; // Изображение закрытого глазика
                }

                // Инвертируем флаг
                isPasswordCreateVisible = !isPasswordCreateVisible;
            }
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string name = richTextBoxCreateName.Text.Trim();
            string login = richTextBoxCreateLogin.Text.Trim();
            string password = textBoxCreatePassword.Text.Trim();
            string confirmPassword = textBoxConfirmPassword.Text.Trim(); // Добавляем получение подтверждения пароля

            // Проверяем, заполнены ли все поля
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем длину логина
            if (login.Length <= 6)
            {
                MessageBox.Show($"Логин должен содержать не менее 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем длину пароля
            if (password.Length <= 6)
            {
                MessageBox.Show($"Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем, что пароли совпадают
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // Проверяем, занят ли логин
                    if (db.Users.Any(u => u.username == login))
                    {
                        MessageBox.Show("Логин уже занят. Пожалуйста, выберите другой логин.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Создаем нового пользователя
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

                    MessageBox.Show("Аккаунт успешно создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Очищаем поля
                    richTextBoxCreateName.Clear();
                    richTextBoxCreateLogin.Clear();
                    textBoxCreatePassword.Clear();
                    textBoxConfirmPassword.Clear(); // Очищаем поле подтверждения пароля

                    new MainForm(this.userId).Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonBFCA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbConfirmPassword_Click(object sender, EventArgs e)
        {
            // Переключаем видимость пароля
            var textBoxConfirmPassword = this.Controls["textBoxConfirmPassword"] as TextBox;
            if (textBoxConfirmPassword != null)
            {
                if (isPasswordConfirmVisible)
                {
                    // Скрыть пароль
                    textBoxConfirmPassword.UseSystemPasswordChar = true;
                    pbConfirmPassword.BackgroundImage = Properties.Resources.visible_password_security_protect_icon; // Изображение открытого глазика
                }
                else
                {
                    // Показать пароль
                    textBoxConfirmPassword.UseSystemPasswordChar = false;
                    pbConfirmPassword.BackgroundImage = Properties.Resources.eye_password_see_view_icon; // Изображение закрытого глазика
                }

                // Инвертируем флаг
                isPasswordConfirmVisible = !isPasswordConfirmVisible;
            }
        }
    }
}
