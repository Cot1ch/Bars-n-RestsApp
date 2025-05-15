using System;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NLog;

namespace RecsApp.forms
{
    /// <summary>
    /// Форма создания аккаунта
    /// </summary>
    public partial class CreateAccount : Form
    {
        /// <summary>
        /// Логгер
        /// </summary>
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
        /// <summary>
        /// Конструктор CreateAccountForm
        /// </summary>
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
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            {
                var name = richTextBoxCreateName.Text.Trim();
                var login = richTextBoxCreateLogin.Text.Trim();
                var password = textBoxCreatePassword.Text.Trim();
                var confirmPassword = textBoxConfirmPassword.Text.Trim();

                logger.Trace("Попытка создания аккаунта");

                if (login.Length < 6)
                {
                    MessageBox.Show(res.GetString("CheckLogin"),
                        res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info("Логин должен содержать не менее 6 символов");
                    return;
                }

                if (!IsValidLoginOrPassword(login))
                {
                    MessageBox.Show(res.GetString("IsValidLogin"),
                        res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info("Логин должен состоять только из английских букв и цифр.");
                    return;
                }

                if (password.Length < 6)
                {
                    MessageBox.Show(res.GetString("CheckPassword"),
                        res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info("Пароль должен содержать не менее 6 символов");
                    return;
                }

                if (!IsValidLoginOrPassword(password))
                {
                    MessageBox.Show(res.GetString("IsValidPassword"),
                        res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info("Пароль должен состоять только из английских букв и цифр.");
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show(res.GetString("PasswordMatch"),
                        res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info("Пароли не совпадают");
                    return;
                }

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login)
                    || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show(res.GetString("FillTheFields"), res.GetString("Error"), 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info("Не все поля заполнены");
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
                            MessageBox.Show(res.GetString("LoginAlreadyUse"),
                                res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        var questionnaire = new Questionnaire() 
                        { 
                            user_Id = newUser.user_Id, 
                            User = newUser 
                        };
                        db.Questionnaires.Add(questionnaire);

                        userId = newUser.user_Id;
                        db.Users.Add(newUser);
                        logger.Info($"Добавлен пользователь {newUser.username}");
                        db.SaveChanges();

                        MessageBox.Show(res.GetString("AccountSuccess"), res.GetString("Success"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        logger.Info("Аккаунта успешно создан");

                        richTextBoxCreateName.Clear();
                        richTextBoxCreateLogin.Clear();
                        textBoxCreatePassword.Clear();
                        textBoxConfirmPassword.Clear();

                        new MainForm(this.userId).Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{res.GetString("HappenedError")} {ex.Message}",
                        res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info($"Произошла ошибка: {ex.Message}");
                }       
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

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resource1.resx"))
            {
                this.Text = res.GetString("CreateAccountText");                
                this.labelCreateAccount.Text = res.GetString("labelCreateAccountText");
                this.labelName.Text = res.GetString("labelNameText");
                this.labelLogin.Text = res.GetString("labelLoginText");
                this.buttonBFCA.Text = res.GetString("buttonBFCAText");
                this.labelPassword.Text = res.GetString("labelPasswordText");
                this.labelConfirmPassword.Text = res.GetString("labelConfirmPasswordText");
                this.buttonCreate.Text = res.GetString("buttonCreateText");

                logger.Info("Локализация выполнена");
            }
        }
    }
}
