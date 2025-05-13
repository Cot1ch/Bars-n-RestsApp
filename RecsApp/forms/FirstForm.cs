using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using RecsApp.forms;
using NLog;

namespace RecsApp
{
    /// <summary>
    /// Основная форма
    /// </summary>
    public partial class FirstForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public FirstForm()
        {
            InitializeComponent();
            logger.Trace("Форма FirstForm загружена");
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.ShowDialog();


            logger.Trace("Форма регистрации запущена");
            this.Hide();
            logger.Trace("Форма FirstForm скрыта");

        }


        private void buttonEntryAccount_Click(object sender, EventArgs e)
        {
            EntryAccount entryAccount = new EntryAccount();
            entryAccount.ShowDialog();


            logger.Trace("Форма входа запущена");
            this.Hide();
            logger.Trace("Форма FirstForm скрыта");

        }

    }
}
