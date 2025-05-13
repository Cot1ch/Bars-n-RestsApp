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
    public partial class FirstForm: Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public FirstForm()
        {
            InitializeComponent();
            logger.Trace("Форма FirstForm загружена");
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount createAccount = new CreateAccount();
            createAccount.FormClosed += CreateAccount_FormClosed;
            createAccount.ShowDialog();
            logger.Trace("Форма регистрации закрыта");
        }


        private void buttonEntryAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            EntryAccount entryAccount = new EntryAccount();
            entryAccount.FormClosed += EntryAccount_FormClosed;
            entryAccount.ShowDialog();

        }
        private void EntryAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void CreateAccount_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
