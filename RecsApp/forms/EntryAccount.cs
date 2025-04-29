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
    public partial class EntryAccount : Form
    {
        public EntryAccount()
        {
            InitializeComponent();
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {

        }

        private void buttonEntry_Paint(object sender, PaintEventArgs e)
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

        private void buttonBFEA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBFEA_Paint(object sender, PaintEventArgs e)
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
    }
}
