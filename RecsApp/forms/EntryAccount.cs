using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            logger.Trace("Попытка входа в аккаунт");
            var login = richTextBoxEntryLogin.Text.Trim();
            var password = textBoxEntryPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Trace("Попытка не удалась: не все поля заполнены");
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var user = GetUserByUsername(db, login);

                    if (user == null)
                    {
                        MessageBox.Show("Такого пользователя не существует",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("Такого пользователя не существует");
                        return;
                    }
                    logger.Trace($"Получен пользователь {user.username}");

                    bool isPasswordValid = false;

                    try
                    {
                        // Проверяем пароль
                        isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password_hash);
                        logger.Info("Проверка существования пароля");
                    }
                    catch (Exception ex)
                    {
                        // Проверяем, является ли ошибка связанной с версией соли
                        if (ex.Message.Contains("Invalid salt version"))
                        {
                            // Перехэшируем пароль
                            string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                            user.password_hash = newHashedPassword;
                            db.SaveChanges();

                            // Повторно проверяем пароль
                            isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password_hash);
                        }
                        else
                        {
                            throw; 
                        }
                    }

                    if (!isPasswordValid)
                    {
                        MessageBox.Show("Пароль неверный.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("Пароль неверный");
                        return;
                    }

                    logger.Info($"Вход в аккаунт {user.username} успешно выполнен");
                    this.Hide();
                    logger.Trace("Форма скрыта");

                    new MainForm(user.user_Id).Show();
                    logger.Trace("Главная форма запущена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error($"Произошла ошибка: {ex.Message}");
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
    }
}
