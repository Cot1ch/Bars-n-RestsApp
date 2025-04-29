using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace RecsApp
{
    public partial class MainForm : Form
    {
        private int imageInd = 0;
        private List<string> paths;

        public MainForm(User user)
        {
            new AppDbContext().Database.Delete();

            InitializeComponent();
            AddTypesToDB();
            AddCategoryesToDB();
            AddEstablishmentsToDB();

            using (var db = new AppDbContext())
            {
                var ests = db.Establishments.ToList();

                //if (types.Count != 0 || categs.Count != 0)
                //{
                //    ests = (
                //        from est in db.Establishments
                //        where types.Contains(est.Type)
                //        where categs.Contains(est.Category)
                //        select est).ToList();
                //}

                listBoxEstablishments.DataSource = ests;
                listBoxEstablishments.DisplayMember = "Name";
                listBoxEstablishments.ValueMember = "Id";
            }
        }

        public void AddTypesToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Типы").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidType) && db.Types.Find(guidType) == null)
                    {
                        db.Types.Add(new EstType() { Id = guidType, Title = row.Cell(1).Value.ToString()});
                    }
                }
                db.SaveChanges();
            }            
        }

        public void AddCategoryesToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Категории").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidCat) && db.Categories.Find(guidCat) == null)
                    {
                        db.Categories.Add(new EstCategory() { Id = guidCat, Title = row.Cell(1).Value.ToString() });
                    }
                }
                db.SaveChanges();
            }
        }

        public void AddEstablishmentsToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Заведения").RowsUsed();
            
            using (var db = new AppDbContext())
            {
                bool IsEmpty = false;
                foreach (var row in ws)
                {
                    if (row.RowNumber() == 1)
                    {
                        continue;
                    }
                    string name = row.Cell(1).Value.ToString();
                    string description = row.Cell(2).Value.ToString();
                    Guid type = GetGuidFromString(row.Cell(3).Value.ToString());
                    List<Guid> categories = new List<Guid>();
                    foreach (var cat in row.Cell(4).Value.ToString().Split(';'))
                    {
                        if (GetGuidFromString(cat) != Guid.Empty)
                        {
                            categories.Add(GetGuidFromString(cat));
                        }
                    }
                    string address = row.Cell(5).Value.ToString();
                    double rating = double.TryParse(row.Cell(6).Value.ToString().Replace('.', ','), out double rat) ? rat : 0;
                    if (rating > 5)
                    {
                        rating = 5;
                    }
                    else if (rating < 0)
                    {
                        rating = 0;
                    }

                    string link = row.Cell(7).Value.ToString();
                    List<string> pathsToPhoto = row.Cell(8).Value.ToString().Split(';').ToList();
                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(description) ||
                        type == Guid.Empty || categories.Count == 0 || string.IsNullOrEmpty(address))
                    {
                        IsEmpty = true;
                    }

                    if ((from est in db.Establishments 
                         where est.Name == name 
                         select est).Count() != 0 
                         &&
                        (from est in db.Establishments 
                         where est.Address == address 
                         select est).Count() != 0)
                    {
                        continue;
                    }

                    db.Establishments.Add(new Establishment(name, description, categories, type, rating, address, link, pathsToPhoto));
                }
                if (IsEmpty)
                {
                    MessageBox.Show("Часть данных утеряна, обратитесь к администратору");
                }
                db.SaveChanges();
            }
        }

        public Guid GetGuidFromString(string strGuid)
        {
            if (Guid.TryParse(strGuid, out Guid guid))
            {
                return guid;
            }
            else
            {
                return Guid.Empty;
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
                this.textBoxEstRating.Text = $"{est.Rating:F1}";
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

        private void linkLabelToWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.linkLabelToWebSite.Text);
        }
    }
}