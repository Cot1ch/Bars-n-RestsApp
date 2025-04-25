using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RecsApp
{
    public partial class MainForm : Form
    {
        private int imageInd = 0;
        private List<string> paths;

        public MainForm()
        {
            InitializeComponent();

            //using (var db = new AppDbContext())
            //{
            //    db.Database.Delete();
            //    db.Categories.Add(new EstCategory() { Id = 1, Title = "Вдвоём" });
            //    db.Categories.Add(new EstCategory() { Id = 2, Title = "хз" });
            //    db.Types.Add(new EstType() { Id = 1, Title = "Ресторан" });
            //    db.Establishments.Add(new Establishment() { Name = "Кыстыбый", Description = "ub", Address = "Пушкина, 2", Rating = 5.0, Link = "", Category = 1, Type = 1 });
            //    db.Establishments.Add(new Establishment() { Name = "Пташка", Description = "uщсгниу", Address = "Университетская хз сколько", Rating = 5.1, Link = "", Category = 2, Type = 1 });
            //    db.SaveChanges();
            //}

            using (var db = new AppDbContext())
            {
                listBoxEstablishments.DataSource = db.Establishments.ToList();
                listBoxEstablishments.DisplayMember = "Name";
                listBoxEstablishments.ValueMember = "Id";
            }
        }

        private void listBoxEstablishments_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMainForm((Establishment)this.listBoxEstablishments.Items[this.listBoxEstablishments.SelectedIndex]);
        }

        public void LoadMainForm(Establishment est)
        {
            using (var db = new AppDbContext())
            {
                this.textBoxEstName.Text = est.Name;
                this.textBoxEstDescription.Text = est.Description;
                this.textBoxEstType.Text = db.Types.Find(est.Type).Title;
                this.textBoxEstRating.Text = est.Rating.ToString();
                this.textBoxEstAddress.Text = est.Address.ToString();
                this.linkLabelToWebSite.Text = (est.Link != string.Empty) ? est.Link : "тут могла быть ссылка, но её нет";

                paths = est.PathsToPhoto.Count == 0 ? new List<string>() { "notfound.png" } : est.PathsToPhoto;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowImage();
        }

        public void ShowImage()
        {
            pictureBoxEstImage.ImageLocation = $"{Directory.GetCurrentDirectory()}\\..\\..\\images\\{paths[imageInd]}";
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
    }
}