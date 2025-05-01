using System;
using System.IO;
using System.Collections.Generic;
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
            using (var db = new AppDbContext())
            {
                db.Database.Delete();
            }
            InitializeComponent();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount createAccount = new CreateAccount();

            createAccount.FormClosed += (s, args) => this.Show();
            createAccount.Show();
        }

        private void buttonCreateAccount_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 5;
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                button.Region = new Region(path);
            }
        }

        private void buttonEntryAccount_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 5;
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                button.Region = new Region(path);
            }
        }

        private void buttonEntryAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            EntryAccount entryAccount = new EntryAccount();

            entryAccount.FormClosed += (s, args) => this.Show();
            entryAccount.Show();
        }
    }
}
