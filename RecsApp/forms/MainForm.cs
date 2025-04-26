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

            //пилотное добавление для показа
            using (var db = new AppDbContext())
            {
                // Фейковое добавление
                db.Database.Delete();
                Guid.TryParse("b971c917-d3ec-4428-b4e5-4d47ea2f163a", out Guid guidCat1);
                Guid.TryParse("ca6c2aa9-4f66-4a51-9bbd-62e775c9d472", out Guid guidCat2);
                db.Categories.Add(new EstCategory() { Id = guidCat1, Title = "Вдвоём" });
                db.Categories.Add(new EstCategory() { Id = guidCat2, Title = "хз" });
                Guid.TryParse("23bbf4c5-0f19-4bfb-aed9-975a40dd9bfc", out Guid guidType1);
                db.Types.Add(new EstType() { Id = guidType1, Title = "Ресторан" });
                db.Establishments.Add(new Establishment() { Name = "Кыстыбый", Description = "ub", Address = "Пушкина, 2", Rating = 5.0, Link = "", Category = guidCat2, Type = guidType1 });
                db.Establishments.Add(new Establishment() { Name = "Пташка", Description = "uщсгниу", Address = "Университетская хз сколько", Rating = 5.1, Link = "", Category = guidCat1, Type = guidType1 });
                db.SaveChanges();
            }

            using (var db = new AppDbContext())
            {
                // переписать с костылей (СЕВА НЕ ЗАБУДЬ ПОЛУЧИШЬ ЖЕ)
                Guid.TryParse("b971c917-d3ec-4428-b4e5-4d47ea2f163a", out Guid guidCat1);
                Guid.TryParse("ca6c2aa9-4f66-4a51-9bbd-62e775c9d472", out Guid guidCat2); 
                Guid.TryParse("23bbf4c5-0f19-4bfb-aed9-975a40dd9bfc", out Guid guidType1);

                var ests = new List<Establishment>();
                
                List<Guid> types = new List<Guid>() 
                {
                    guidType1,
                    Guid.NewGuid()

                };
                List<Guid> categs = new List<Guid>() 
                {
                    guidCat1,
                    guidCat2
                };

                if (types.Count != 0 || categs.Count != 0)
                {
                    ests = (
                        from est in db.Establishments
                        where types.Contains(est.Type)
                        where categs.Contains(est.Category)
                        select est).ToList();
                }
                else
                {
                    ests = db.Establishments.ToList();
                }
                // вот до сюда переписать

                listBoxEstablishments.DataSource = ests;
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

        private void btnAccount_Click(object sender, EventArgs e)
        {
            new AccountForm().Show();
        }
    }
}