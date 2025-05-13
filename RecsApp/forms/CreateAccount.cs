using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BCrypt.Net;
using NLog;

namespace RecsApp.forms
{
    /// <summary>
    /// Форма создания аккаунта
    /// </summary>
    public partial class CreateAccount : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Идентификатор аккаунта пользователя
        /// </summary>
        private Guid userId;
        /// <summary>
        /// Переменные для работы "глазика"
        /// </summary>
        private bool isPasswordCreateVisible = true;
        private bool isPasswordConfirmVisible = true;
        /// <summary>
        /// Переменная для проверки свободного логина
        /// </summary>
        bool isUsernameTaken = false;
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void pbShowPassword_Click(object sender, EventArgs e)
        {
            var textBoxCreatePassword = this.Controls["textBoxCreatePassword"] as TextBox;
            logger.Trace("Нажата кнопка изменения видимости пароля");
            if (textBoxCreatePassword != null)
            {
                if (isPasswordCreateVisible)
                {
                    textBoxCreatePassword.UseSystemPasswordChar = false;
                    pbShowPassword.BackgroundImage =
                        Properties.Resources.visible_password_security_protect_icon;
                    logger.Trace("Текущее состояние: видимый");
                }
                else
                {
                    textBoxCreatePassword.UseSystemPasswordChar = true;
                    pbShowPassword.BackgroundImage =
                        Properties.Resources.eye_password_see_view_icon;
                    logger.Trace("Текущее состояние: скрытый");
                }

                isPasswordCreateVisible = !isPasswordCreateVisible;
            }
            else
            {
                logger.Info("Поле пароля пусто");
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var name = richTextBoxCreateName.Text.Trim();
            var login = richTextBoxCreateLogin.Text.Trim();
            var password = textBoxCreatePassword.Text.Trim();
            var confirmPassword = textBoxConfirmPassword.Text.Trim();

            logger.Trace("Попытка создания аккаунта");

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login)
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Не все поля заполнены");
                return;
            }

            if (login.Length < 6)
            {
                MessageBox.Show($"Логин должен содержать не менее 6 символов.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Логин должен содержать не менее 6 символов");
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show($"Пароль должен содержать не менее 6 символов.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Пароль должен содержать не менее 6 символов");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Пароли не совпадают");
                return;
            }

            if (!IsValidLoginOrPassword(login))
            {
                MessageBox.Show("Логин должен состоять только из английских букв и цифр.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Логин должен состоять только из английских букв и цифр.");
                return;
            }

            if (!IsValidLoginOrPassword(password))
            {
                MessageBox.Show("Пароль должен состоять только из английских букв и цифр.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Пароль должен состоять только из английских букв и цифр.");
                return;
            }
            try
            {
                using (var db = new AppDbContext())
                {
                    foreach (var user in db.Users)
                    {
                        if (user.username == login)
                        {
                            isUsernameTaken = true;
                            break;
                        }
                    }
                    if (isUsernameTaken)
                    {
                        MessageBox.Show("Логин уже занят. Пожалуйста, выберите другой логин.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Info("Логин уже занят");
                        return;
                    }

                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    var newUser = new User
                    {
                        user_Id = Guid.NewGuid(),
                        name = name,
                        username = login,
                        password_hash = password
                    };

                    var questionnaire = new Questionnaire() { user_Id = newUser.user_Id };
                    userId = newUser.user_Id;
                    db.Users.Add(newUser);
                    db.Questionnaires.Add(questionnaire);
                    db.SaveChanges();

                    MessageBox.Show("Аккаунт успешно создан.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Аккаунт успешно создан");

                    richTextBoxCreateName.Clear();
                    richTextBoxCreateLogin.Clear();
                    textBoxCreatePassword.Clear();
                    textBoxConfirmPassword.Clear(); 

                    new MainForm(this.userId).Show();
                    logger.Trace("Отображена главная форма");
                    this.Hide();
                    logger.Trace("Форма создания аккаунта закрыта");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info($"Произошла ошибка: {ex.Message}");
            }
        }
        /// <summary>
        /// Метод для проверки правильности пароля
        /// </summary>
        private bool IsValidLoginOrPassword(string input)
        {
            var pattern = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(input, pattern);
        }


        private void buttonBFCA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbConfirmPassword_Click(object sender, EventArgs e)
        {
            var textBoxConfirmPassword = this.Controls["textBoxConfirmPassword"] as TextBox;
            logger.Trace("Нажата кнопка изменения видимости пароля");
            if (textBoxConfirmPassword != null)
            {
                if (isPasswordConfirmVisible)
                {
                    textBoxConfirmPassword.UseSystemPasswordChar = false;
                    pbConfirmPassword.BackgroundImage =
                        Properties.Resources.visible_password_security_protect_icon;
                    logger.Trace("Текущее состояние: видимый");
                }
                else
                {
                    textBoxConfirmPassword.UseSystemPasswordChar = true;
                    pbConfirmPassword.BackgroundImage =
                        Properties.Resources.eye_password_see_view_icon;
                    logger.Trace("Текущее состояние: скрытый");
                }

                isPasswordConfirmVisible = !isPasswordConfirmVisible;
            }
            else
            {
                logger.Info("Поле пароля пусто");
            }
        }
    }
}
