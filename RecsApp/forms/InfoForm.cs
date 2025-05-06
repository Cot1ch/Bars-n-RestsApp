using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace RecsApp
{
    public partial class InfoForm : Form
    {
        private Establishment est;
        private int imageInd = 0;
        private List<string> paths;
        public InfoForm(Guid EstId, Guid userId)
        {
            InitializeComponent();
            using (var db = new AppDbContext()) 
            {
                est = (from e in db.Establishments.Include(e => e.Type).Include(e => e.Categories).Include(e => e.Foods).Include(e => e.Averages)
                       where e.Id == EstId
                      select e).First();
            }
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            LoadInfoForm();
            ShowImage();
        }
        /// <summary>
        /// Метод заполняет текстовые поля, поля ссылки и изображений заведения для отображения информации о нём
        /// </summary>
        public void LoadInfoForm()
        {
            using (var db = new AppDbContext())
            {
                this.textBoxEstName.Text = est.Name;
                this.textBoxEstDescription.Text = est.Description;

                this.textBoxEstType.Text = est.Type.Title;
                this.textBoxEstRating.Text = $"{est.Rating:F1}";
                this.textBoxEstAddress.Text = est.Address.ToString();
                this.linkLabelToWebSite.Text = (est.Link != string.Empty) ? est.Link : "ссылка отсутствует";

                paths = est.PathsToPhoto.Count == 0 ? new List<string>() { "notfound.png" } : est.PathsToPhoto;
            }
        }
        /// <summary>
        /// Метод передает в picturebox путь к изображению
        /// </summary>
        public void ShowImage()
        {
            if (paths != null)
            {
                pictureBoxEstImage.ImageLocation = $"{Directory.GetCurrentDirectory()}\\..\\..\\images\\{paths[imageInd]}";
            }
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            PrevImage();
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            NextImage();
        }
        private void linkLabelToWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this.linkLabelToWebSite.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ссылка отсутствует");
            }
        }

        private void NextImage()
        {
            imageInd = (imageInd + 1) % paths.Count;
            ShowImage();
        }
        private void PrevImage()
        {
            imageInd = (imageInd - 1 + paths.Count) % paths.Count;
            ShowImage();
        }

        private void InfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                PrevImage();
            }
            if (e.KeyCode == Keys.Right)
            {
                NextImage();
            }
        }
    }
}
