using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using DocumentFormat.OpenXml.Presentation;

namespace RecsApp
{
    public partial class MainForm : Form
    {
        public Guid userId;
        public bool IsRatingMore4nHalf = false;
        
        public MainForm(Guid usId)
        {
            InitializeComponent();
            userId = usId;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AddFromExcel.AddTypesToDB();
            AddFromExcel.AddCategoryesToDB();
            AddFromExcel.AddFoodToDB();
            AddFromExcel.AddAveragesToDB();

            AddFromExcel.AddEstablishmentsToDB();

            LoadForm();
            SetdgvEstablishments();
        }
        /// <summary>
        /// Метод прогружает datagrid со всеми заведениями, подхоядзими под выбранные пункты анкеты
        /// </summary>
        public void LoadForm()
        {
            using (var db = new AppDbContext())
            {
                var user =
                    (from u in db.Users.Include(u => u.est_types).Include(u => u.est_categories)
                    where u.user_Id == userId
                    select u).First();
                var ests = db.Establishments.ToList();
                var types = user.est_types.Select(t => t.Id).ToList();
                var categories = user.est_categories.Select(c => c.Id).ToList();
                var foods = user.est_foods.Select(f => f.Id).ToList();
                var averages = user.est_averages.Select(a => a.Id).ToList();
                
                if (user.est_types != null && user.est_types.Count != 0)
                {
                    ests = (
                        from est in db.Establishments.Include(e => e.Type).Include(e => e.Categories).Include(e => e.Foods).Include(e => e.Averages)
                        where types.Contains(est.Type.Id)
                        select est).ToList();
                }
                if (user.est_categories != null && user.est_categories.Count != 0)
                {
                    ests = (
                        from est in db.Establishments.Include(e => e.Type).Include(e => e.Categories).Include(e => e.Foods).Include(e => e.Averages)
                        where est.Categories.Select(cat => cat.Id).Any(c => categories.Contains(c))
                        select est).ToList();
                }
                if (user.est_foods != null && user.est_foods.Count != 0)
                {
                    ests = (
                        from est in db.Establishments.Include(e => e.Type).Include(e => e.Categories).Include(e => e.Foods).Include(e => e.Averages)
                        where est.Foods.Any(f => user.est_foods.Contains(f))
                        select est).ToList();
                }
                if (user.est_averages != null && user.est_averages.Count != 0)
                {
                    ests = (
                        from est in db.Establishments.Include(e => e.Type).Include(e => e.Categories).Include(e => e.Foods).Include(e => e.Averages)
                        where est.Averages.Any(f => user.est_averages.Contains(f))
                        select est).ToList();
                }
                if (IsRatingMore4nHalf)
                {
                    ests = (
                        from est in ests
                        where est.Rating >= 4.5
                        select est).ToList();
                }

                var finalEsts = from e in ests
                                join t in db.Types on e.Type equals t
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

        /// <summary>
        /// Метод настраивает datagridview
        /// </summary>
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
        /// <summary>
        /// Метод вызывает форму с подробной информацией о заведении
        /// </summary>
        public void ShowInfoForm(Guid id)
        {
            new InfoForm(id, this.userId).Show();
        }
    }
}