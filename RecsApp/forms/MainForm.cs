using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Presentation.Command;

namespace RecsApp
{
    public partial class MainForm : Form
    {
        public Guid userId;
        public List<Guid> typeIds;
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
                var user = db.Users.Find(userId);
                //
                user.type_id = this.typeIds;
                //
                var ests = db.Establishments.ToList();

                if (user.type_id != null && user.type_id.Count != 0)
                {
                    ests = (
                        from est in db.Establishments
                        where user.type_id.Contains(est.Type)
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
        /// <summary>
        /// Метод загружает типы заведений из Excel файла
        /// </summary>

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