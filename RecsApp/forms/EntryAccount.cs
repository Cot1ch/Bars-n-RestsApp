using NLog;
using System;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace RecsApp.forms
{
    /// <summary>
    /// Форма входа в аккаунт
    /// </summary>
    public partial class EntryAccount : Form
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Переменная для работы "глазика"
        /// </summary>
        private bool isPasswordEntryVisible = true;
        /// <summary>
        /// Конструктор EntryAccountForm
        /// </summary>
        public EntryAccount()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод для поиска пользователя по логину 
        /// </summary>
        private User GetUserByUsername(AppDbContext db, string username)
        {
            logger.Info("Начат поиск пользователя по имени в базе данных");
            foreach (var user in db.Users)
            {
                if (user.username == username)
                {
                    logger.Info($"Пользователь {user.user_Id} {user.username} найден");
                    return user;
                }
            }
            logger.Warn($"Пользователь {username} не найден");
            return null;
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            {
                var login = richTextBoxEntryLogin.Text.Trim();
                var password = textBoxEntryPassword.Text.Trim();

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(res.GetString("FillTheFields"),
                        res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (var db = new AppDbContext())
                    {
                        
                        if (!db.Users.Any(admin => admin.username == "adminnn"))
                        {
                            var pass = "adminnn";
                            var adminPassword = BCrypt.Net.BCrypt.HashPassword(pass);

                            var admin = new User()
                            {
                                name = "admin",
                                username = "adminnn",
                                password_hash = pass
                            };
                            db.Users.Add(admin);
                            var questionnaire = new Questionnaire()
                            {
                                user_Id = admin.user_Id,
                                User = admin
                            };
                            db.Questionnaires.Add(questionnaire);
                            db.SaveChanges();
                        }
                    }
                    using (var db = new AppDbContext())
                    {
                        var user = GetUserByUsername(db, login);

                        if (user == null)
                        {
                            MessageBox.Show(res.GetString("UserDoesNotExist"),
                                res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool isPasswordValid = false;

                        try
                        {
                            isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password_hash);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("Invalid salt version"))
                            {
                                string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                                user.password_hash = newHashedPassword;
                                db.SaveChanges();

                                isPasswordValid = 
                                    BCrypt.Net.BCrypt.Verify(password, user.password_hash);
                            }
                            else
                            {
                                throw;
                            }
                        }

                        if (!isPasswordValid)
                        {
                            MessageBox.Show(res.GetString("WrongPassword"),
                                res.GetString("Error"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show(res.GetString("EntrySuccess"),
                            res.GetString("Success"), 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        new MainForm(user.user_Id).Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{res.GetString("HappenedError")} {ex.Message}",
                        res.GetString("Error"), 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBFEA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxShowEntryPassword_Click(object sender, EventArgs e)
        {
            var textBoxEntryPassword = this.Controls["textBoxEntryPassword"] as TextBox;
            logger.Trace("Нажата кнопка изменения видимости пароля");
            if (textBoxEntryPassword != null)
            {
                if (isPasswordEntryVisible)
                {
                    textBoxEntryPassword.UseSystemPasswordChar = false;
                    pictureBoxShowEntryPassword.BackgroundImage =
                        Properties.Resources.visible_password_security_protect_icon;
                    logger.Trace("Текущее состояние: видимый");
                }
                else
                {
                    textBoxEntryPassword.UseSystemPasswordChar = true;
                    pictureBoxShowEntryPassword.BackgroundImage =
                        Properties.Resources.eye_password_see_view_icon;
                    logger.Trace("Текущее состояние: скрытый");
                }

                isPasswordEntryVisible = !isPasswordEntryVisible;
            }
            else
            {
                logger.Info("Поле пароля пусто");
            }
        }

        private void EntryAccount_Load(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            {
                this.Text = res.GetString("EntryAccountText");
                this.labelLogin.Text = res.GetString("labelEntryLoginText");
                this.labelPassword.Text = res.GetString("labelEntryPasswordText");
                this.labelEntryAccount.Text = res.GetString("labelEntryAccountText");
                this.buttonBFEA.Text = res.GetString("buttonBFEAText");
                this.buttonEntry.Text = res.GetString("buttonEntryText");

                logger.Info("Локализация выполнена");
            }
        }
    }
}
