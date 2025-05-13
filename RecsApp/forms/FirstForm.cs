using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using RecsApp.forms;

namespace RecsApp
{
    /// <summary>
    /// Основная форма
    /// </summary>
    public partial class FirstForm: Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount createAccount = new CreateAccount();
            createAccount.FormClosed += CreateAccount_FormClosed;
            createAccount.ShowDialog();
            //this.WindowState = FormWindowState.Minimized;
        }


        private void buttonEntryAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            EntryAccount entryAccount = new EntryAccount();
            entryAccount.FormClosed += EntryAccount_FormClosed;
            entryAccount.ShowDialog();
            //this.WindowState = FormWindowState.Minimized;

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
