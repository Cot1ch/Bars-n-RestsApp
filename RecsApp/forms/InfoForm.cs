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
        private Guid userId;
        private MainForm mainForm;
        public InfoForm(Guid EstId, Guid UserId, MainForm main)
        {
            InitializeComponent();
            this.userId = UserId;
            mainForm = main;
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
                this.textBoxFood.Text = string.Join("; ", est.Foods.Select(f => f.Title).ToList());
                this.textBoxEstType.Text = est.Type.Title;
                this.textBoxEstRating.Text = $"{est.Rating:F1}";
                this.textBoxEstAddress.Text = est.Address.ToString();
                this.linkLabelToWebSite.Text = (est.Link != string.Empty) ? est.Link : "ссылка отсутствует";
                this.checkBoxStarred.Checked = db.Users.Find(userId).Favourite.Contains(this.est);
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
            catch 
            {
                MessageBox.Show("Приносим свои извинения\nУ данного заведения отсутствует сайт :(", "Ссылка отсутствует", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void checkBoxStarred_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var user = (from u in db.Users
                            where u.user_Id == this.userId
                            select u).First();
                db.Establishments.Attach(this.est);
                if (this.checkBoxStarred.Checked)
                {
                    if (user != null)
                    {
                        if (!user.Favourite.Contains(this.est))
                        {
                            user.Favourite.Add(this.est);
                            MessageBox.Show("Заведение добавлено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Уже добавлено");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Доступ к аккаунту потерян", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (user != null)
                    {
                        user.Favourite.Remove(this.est);
                        MessageBox.Show("Заведение удалено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Доступ к аккаунту потерян", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                db.SaveChanges();
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Вы больше не увидите это событие\nПродолжить?", "Вы уверены?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                using (var db = new AppDbContext())
                {
                    var user = (from u in db.Users.Include(u => u.Hidden)
                                where u.user_Id == this.userId
                                select u).First();
                    db.Establishments.Attach(this.est);
                    user.Hidden.Add(this.est);
                    db.SaveChanges();

                }
                mainForm.LoadForm();
                this.Close();
            }
        }
    }
}
