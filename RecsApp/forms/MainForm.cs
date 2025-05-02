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
        public Guid userId;
        public MainForm(Guid usId)
        {
            InitializeComponent();
            userId = usId;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AddTypesToDB();
            AddCategoryesToDB();
            AddFoodToDB();
            AddAveragesToDB();

            AddEstablishmentsToDB();

            LoadForm();
            SetdgvEstablishments();
        }
        public void LoadForm()
        {
            using (var db = new AppDbContext())
            {
                var user = db.Users.Find(userId);
                var ests = db.Establishments.ToList();

                if (user.type_id != null && user.type_id.Count != 0)
                {
                    ests = (
                        from est in db.Establishments
                        where user.type_id.Contains(est.Type)
                        //where est.Category.Any(x => user.categoty_id.Contains(x))
                        select est).ToList();
                }

                var finalEsts = from e in ests
                                join t in db.Types on e.Type equals t.Id
                                select new { e.Id, Название = e.Name, Тип = t.Title, Рейтинг = e.Rating };

                dgvEstablishments.DataSource = finalEsts.ToList();
            }
            for (int i = 0; i < dgvEstablishments.Rows.Count; i++)
            {
                dgvEstablishments.Rows[i].DefaultCellStyle.BackColor =
                    System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));
                dgvEstablishments.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
                dgvEstablishments.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
        public void AddFoodToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Кухня").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidFood) && db.Foods.Find(guidFood) == null)
                    {
                        db.Foods.Add(new EstFood() { Id = guidFood, Title = row.Cell(1).Value.ToString() });
                    }
                }
                db.SaveChanges();
            }
        }
        public void AddAveragesToDB()
        {
            string path = $"{Directory.GetCurrentDirectory()}..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден!\nОбратитесь к администратору");
                return;
            }

            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet("Средний чек").RowsUsed();

            using (var db = new AppDbContext())
            {
                foreach (var row in ws)
                {
                    if (Guid.TryParse(row.Cell(2).Value.ToString(), out Guid guidAv) && db.AverageChecks.Find(guidAv) == null)
                    {
                        db.AverageChecks.Add(new EstAverageCheck() { Id = guidAv, Title = row.Cell(1).Value.ToString() });
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
        private void SetdgvEstablishments()
        {
            dgvEstablishments.Columns[0].Visible = false;
            dgvEstablishments.RowHeadersVisible = false;
            dgvEstablishments.EnableHeadersVisualStyles = false;
            dgvEstablishments.ColumnHeadersDefaultCellStyle.BackColor =
                    System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(227)))));    
            dgvEstablishments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
            dgvEstablishments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(72)))), ((int)(((byte)(49)))));
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            new AccountForm(this.userId, this).Show();
        }
        private void dgvEstablishments_DoubleClick(object sender, EventArgs e)
        {
            ShowInfoForm((Guid)this.dgvEstablishments.CurrentRow.Cells[0].Value);
        }
        public void ShowInfoForm(Guid id)
        {
            new InfoForm(id, this.userId).Show();
        }
    }
}