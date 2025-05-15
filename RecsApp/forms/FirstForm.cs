using System;
using System.Windows.Forms;
using RecsApp.forms;
using NLog;
using System.IO;
using System.Resources;

namespace RecsApp
{
    /// <summary>
    /// Основная форма
    /// </summary>
    public partial class FirstForm : Form
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Конструктор FirstForm
        /// </summary>
        public FirstForm()
        {
            InitializeComponent();
            logger.Trace("Форма FirstForm загружена");
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();

            logger.Trace("Форма регистрации запущена");
        }
        private void buttonEntryAccount_Click(object sender, EventArgs e)
        {
            EntryAccount entryAccount = new EntryAccount();
            entryAccount.Show();

            logger.Trace("Форма входа запущена");
        }
        private void FirstForm_Load(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            {
                this.Text = res.GetString("FirstFormText");
                this.labelMain.Text = res.GetString("labelMainText");
                this.buttonCreateAccount.Text = res.GetString("buttonCreateAccountText");
                this.buttonEntryAccount.Text = res.GetString("buttonEntryAccountText");
            }
            logger.Trace("Основная форма запущена");
        }
    }
}
