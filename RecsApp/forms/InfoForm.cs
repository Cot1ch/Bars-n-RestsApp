using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
            est = new AppDbContext().Establishments.Find(EstId);
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            LoadInfoForm();
            ShowImage();
        }

        public void LoadInfoForm()
        {
            using (var db = new AppDbContext())
            {
                this.textBoxEstName.Text = est.Name;
                this.textBoxEstDescription.Text = est.Description;

                this.textBoxEstType.Text = db.Types.Find(est.Type).Title;
                this.textBoxEstRating.Text = $"{est.Rating:F1}";
                this.textBoxEstAddress.Text = est.Address.ToString();
                this.linkLabelToWebSite.Text = (est.Link != string.Empty) ? est.Link : "ссылка отсутствует";

                paths = est.PathsToPhoto.Count == 0 ? new List<string>() { "notfound.png" } : est.PathsToPhoto;
            }
        }

        public void ShowImage()
        {
            if (paths != null)
            {
                pictureBoxEstImage.ImageLocation = $"{Directory.GetCurrentDirectory()}\\..\\..\\images\\{paths[imageInd]}";
            }
            return;
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            imageInd = (imageInd - 1 + paths.Count) % paths.Count;
            ShowImage();
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            imageInd = (imageInd + 1) % paths.Count;
            ShowImage();
        }
        private void linkLabelToWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.linkLabelToWebSite.Text);
        }
    }
}
