using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using RecsApp.forms;

namespace RecsApp
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount createAccount = new CreateAccount();
            createAccount.FormClosed += (s, args) => this.Show();
            createAccount.ShowDialog();
            //this.WindowState = FormWindowState.Minimized;
        }


        private void buttonEntryAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            EntryAccount entryAccount = new EntryAccount();
            entryAccount.FormClosed += (s, args) => this.Show();
            entryAccount.ShowDialog();
            this.MinimizeBox = true;
        }
    }
}
