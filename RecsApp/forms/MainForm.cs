using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using System.Data.Entity;
using System.IO;
using NLog;

namespace RecsApp
{
    /// <summary>
    /// Форма со списками заведений
    /// </summary>
    public partial class MainForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Идентификатор аккаунта пользователя
        /// </summary>
        public Guid userId;
        /// <summary>
        /// Поле для фиксирования запроса отображения только заведений с рейтингом 5.0
        /// </summary>
        public bool isRatingEqualsFive;
        /// <summary>
        /// Поле, задающее способ сортировки
        /// </summary>
        public string sortMode="visits";
        /// <summary>
        /// Путь к файлу с заведениями
        /// </summary>
        private string fileName;
        private string defFileName = $"{Directory.GetCurrentDirectory()}" +
                $"..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
        
        public MainForm(Guid usId)
        {
            InitializeComponent();
            userId = usId;
            this.fileName = $"{Directory.GetCurrentDirectory()}" +
                $"..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
            if (this.fileName != this.defFileName)
            {
                MessageBox.Show($"Загружен файл {this.fileName}",
                    "файл загружен",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AddFromExcel.fileName = this.fileName;
            AddFromExcel.AddTypesCatsFoodsChecksToDB();
            AddFromExcel.AddEstablishmentsToDB();

            logger.Trace("Данные из Excel таблиц загружены");
            this.radioBtnSortByVisits.Checked = true;

            using (var db = new AppDbContext())
            {
                logger.Trace("Выполняется проверка на администратора");
                var user =
                    (from u in db.Users
                     .Include(u => u.Favourite)
                     where u.user_Id == userId
                     select u).First();

                if (user.username == "adminnn")
                {
                    this.btnChangeFile.Visible = true;
                    logger.Info("Кнопка для администратора сделана видимой");
                }
            }

            LoadForm();
            logger.Trace("dataGridView's заполнены");

            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\forms\\MainForm.resx"))
            {
                this.Text = res.GetString("MainFormText");
                this.radioBtnSortByVisits.Text = res.GetString("radioBtnSortByVisitsText");
                this.labelMayLike.Text = res.GetString("labelMayLikeText");
                this.radioBtnSortByRating.Text = res.GetString("radioBtnSortByRatingText");
                this.radioBtnSortByName.Text = res.GetString("radioBtnSortByNameText");
                this.radioBtnSortByType.Text = res.GetString("radioBtnSortByTypeText");
                this.checkBoxFavorite.Text = res.GetString("checkBoxFavoriteText");
                this.labelSorting.Text = res.GetString("labelSortingText");
                this.labelEstsList.Text = res.GetString("labelEstsListText");
                this.btnAccount.Text = res.GetString("btnAccountText");

                if (dgvEstablishments.Columns.Count > 0)
                {
                    dgvEstablishments.Columns[1].HeaderText = 
                        res.GetString("dgvEstablishmentsColumns1HeaderText");
                    dgvEstablishments.Columns[2].HeaderText = 
                        res.GetString("dgvEstablishmentsColumns2HeaderText");
                    dgvEstablishments.Columns[3].HeaderText = 
                        res.GetString("dgvEstablishmentsColumns3HeaderText");
                }
                if (dgvMayLike.Columns.Count > 0)
                {
                    dgvMayLike.Columns[1].HeaderText = res.GetString("dgvMayLikeColumns1HeaderText");
                    dgvMayLike.Columns[2].HeaderText = res.GetString("dgvMayLikeColumns2HeaderText");
                }
                logger.Trace("Локализация настроена");
            }
        }
        /// <summary>
        /// Метод прогружает datagrid со всеми заведениями, подходящими под выбранные пункты анкеты
        /// </summary>
        public void LoadForm(bool showOnlyFavourite=false)
        {
            if (!showOnlyFavourite)
            {
                this.checkBoxFavorite.Checked = false;
            }
            LoaddgvEstablishments(showOnlyFavourite);
            logger.Trace("dataGridView со всеми заведениями заполнен");
            LoaddgvMayLike();
            logger.Trace("dataGridView рекомендованных заведений заполнен");
        }

        /// <summary>
        /// Метод настраивает datagridview всех заведений
        /// </summary>
        private void LoaddgvEstablishments(bool showOnlyFavourite = false)
        {
            using (var db = new AppDbContext())
            {
                var user =
                    (from u in db.Users
                     .Include(u => u.Favourite)
                     .Include(u => u.Hidden)
                     where u.user_Id == userId
                     select u).First();
                logger.Info($"Получен пользователь {user.username}");

                var ests = db.Establishments.
                    Include(e => e.Type).Include(e => e.Categories).
                    Include(e => e.Foods).Include(e => e.Average).ToList();
                logger.Info("Получен список всех заведений");

                if (db.Questionnaires.Count() != 0)
                {
                    var questionnaire = db.Questionnaires
                        .Include(quest => quest.Est_Types)
                        .Include(quest => quest.Est_Categories)
                        .Include(quest => quest.Est_Foods)
                        .Include(quest => quest.Est_Average).ToList()
                        .FirstOrDefault(quest => quest.user_Id == this.userId);
                    logger.Info("Получена анкета пользователя");


                    if (questionnaire != null && !(
                        questionnaire.Est_Average.Count == 0 && 
                        questionnaire.Est_Types.Count == 0 &&
                        questionnaire.Est_Foods.Count == 0 && 
                        questionnaire.Est_Categories.Count == 0))
                    {
                        var types = questionnaire.Est_Types.Select(t => t.Id).ToList();
                        var categories = questionnaire.Est_Categories.Select(c => c.Id).ToList();
                        var foods = questionnaire.Est_Foods.Select(f => f.Id).ToList();
                        var average = questionnaire.Est_Average.Select(a => a.Id).ToList();

                        if (types != null && types.Count != 0)
                        {
                            ests = (
                                from est in ests
                                where types.Contains(est.Type.Id)
                                select est).ToList();
                            logger.Info("Заведения отфильтрованы по типу");
                        }
                        if (categories != null && categories.Count != 0)
                        {
                            ests = (
                                from est in ests
                                where est.Categories.Select(cat => cat.Id)
                                    .Any(c => categories.Contains(c))
                                select est).ToList();
                            logger.Info("Заведения отфильтрованы по категориям");
                        }
                        if (foods != null && foods.Count != 0)
                        {
                            ests = (
                                from est in ests
                                where est.Foods.Select(food => food.Id).Any(c => foods.Contains(c))
                                select est).ToList();
                            logger.Info("Заведения отфильтрованы по кухне");
                        }
                        if (average != null && average.Count != 0)
                        {
                            ests = (
                                from est in ests
                                where average.Contains(est.Average.Id)
                                select est).ToList();
                            logger.Info("Заведения отфильтрованы по среднему чеку");
                        }
                    }
                }
                if (showOnlyFavourite)
                {
                    ests = (
                        from est in ests
                        where user.Favourite.Contains(est)
                        select est).ToList();
                    logger.Info("Выбраны только избранные");
                }
                if (isRatingEqualsFive)
                {
                    ests = (
                        from est in ests
                        where est.Rating == 5.0
                        select est).ToList();
                    logger.Info("Выбраны только заведения с рейтингом 5.0");
                }
                ests = (
                    from est in ests
                    where !user.Hidden.Contains(est)
                    select est).ToList();

                ests.Sort(new SortBySmth()
                {
                    SortMode = this.sortMode
                });
                logger.Info($"Заведения отсортированы, sortMode={sortMode}");

                var finalEsts = from e in ests
                                join t in db.Types on e.Type equals t
                                select new
                                {
                                    e.Id,
                                    Название = e.Name,
                                    Тип = t.Title,
                                    Рейтинг = e.Rating
                                };

                dgvEstablishments.DataSource = finalEsts.ToList();
                logger.Info("datagridview заполнен");
            }

            SetdgvEstablishments();
            logger.Info("datagridview настроен");
        }
        /// <summary>
        /// Настройка отображения dataGridView всех заведений: отображение заголовков, 
        /// цвет текста и фона
        /// </summary>
        private void SetdgvEstablishments()
        {
            for (int i = 0; i < dgvEstablishments.Rows.Count; i++)
            {
                dgvEstablishments.Rows[i].DefaultCellStyle.BackColor =
                    System.Drawing.Color.FromArgb(
                        ((int)(((byte)(247)))), 
                        ((int)(((byte)(246)))), 
                        ((int)(((byte)(227))))
                        );
                dgvEstablishments.Rows[i].DefaultCellStyle.ForeColor = 
                    System.Drawing.Color.FromArgb(
                        ((int)(((byte)(103)))), 
                        ((int)(((byte)(72)))), 
                        ((int)(((byte)(49)))));
                dgvEstablishments.Rows[i].DefaultCellStyle.Font = 
                    new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
            dgvEstablishments.Columns[0].Visible = false;
            dgvEstablishments.RowHeadersVisible = false;
            dgvEstablishments.EnableHeadersVisualStyles = false;
            dgvEstablishments.ColumnHeadersDefaultCellStyle.BackColor =
                    System.Drawing.Color.FromArgb(
                        ((int)(((byte)(247)))), 
                        ((int)(((byte)(246)))), 
                        ((int)(((byte)(227)))));
            dgvEstablishments.ColumnHeadersDefaultCellStyle.Font = 
                new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
            dgvEstablishments.ColumnHeadersDefaultCellStyle.ForeColor = 
                System.Drawing.Color.FromArgb(
                        ((int)(((byte)(103)))), 
                        ((int)(((byte)(72)))), 
                        ((int)(((byte)(49)))));
        }
        /// <summary>
        /// Загрузка dataGridView с рекомендованными заведениями
        /// </summary>
        private void LoaddgvMayLike()
        {
            using (var db = new AppDbContext())
            {
                var user =
                    (from u in db.Users
                     .Include(u => u.Favourite)
                     .Include(u => u.Hidden)                     
                     where u.user_Id == userId
                     select u).First();
                logger.Info($"Получен пользователь {user.username}");
                var ests = db.Establishments.
                    Include(e => e.Type).Include(e => e.Categories).
                    Include(e => e.Foods).Include(e => e.Average).ToList();
                logger.Info("Получен список всех заведений");
                ests.Sort(new SortBySmth()
                {
                    SortMode = "visits"
                });
                logger.Info("Список отсортирован по популярности");
                var simEsts = new List<string>();

                if (user.Favourite.Count < 5)
                {
                    logger.Trace("Начато формирования списка рекомендованных заведений");
                    foreach (var e in ests)
                    {
                        foreach (var sim in e.Similar.Split(';'))
                        {
                            if (!simEsts.Contains(sim))
                            {
                                simEsts.Add(sim);
                                logger.Trace($"Добавлено заведение '{sim}'");
                            }
                        }
                    }
                }
                else
                {
                    var fEstablishments = (
                        from e in ests
                        where user.Favourite.Contains(e)
                        select e).ToList();
                    logger.Trace("Начато формирования списка рекомендованных заведений");
                    foreach (var establishment in fEstablishments)
                    {
                        foreach (var sim in establishment.Similar.Split(';'))
                        {
                            simEsts.Add(sim);
                            logger.Trace($"Добавлено заведение '{sim}'");
                        }
                    }

                    while (simEsts.Count > 10)
                    {
                        Random rnd = new Random();
                        var removeInd = rnd.Next(simEsts.Count);
                        logger.Trace($"Из списка убрано заведение '{simEsts[removeInd]}'");
                        simEsts.RemoveAt(removeInd);
                    }
                }
                var Ests = (
                    from e in db.Establishments
                    where simEsts.Contains(e.Name)
                    select e).ToList();
                logger.Info("Список рекомендованных заведений получен");

                LoadRecsList(Ests, user);

                Ests.Sort(new SortBySmth() 
                { 
                    SortMode = "visits" 
                });
                logger.Info("Список рекомендованных заведений отсортирован по популярности");

                var finalEsts = (
                    from e in Ests.Take(10)
                    select new { e.Id, e.Name, e.Rating }).ToList();
                dgvMayLike.DataSource = finalEsts;
                logger.Info("datagridview заполнен");
            }
            SetdgvMayLike();
            logger.Info("datagridview настроен");
        }
        private void LoadRecsList(List<Establishment> establishments, User user)
        {
            establishments = (
                    from est in establishments
                    where !user.Hidden.Contains(est) 
                    && !user.Favourite.Contains(est)
                    select est).ToList();
            logger.Trace("Получен список рекомендованных заведений " +
                "проверен на наличие скрытых и избранных");
            logger.Trace($"длина списка - {establishments.Count}");
            if (establishments.Count < 10)
            {
                logger.Info("В рекомендованном списке меньше 10 заведений");
                using (var db = new AppDbContext())
                {
                    var ests = db.Establishments.ToList();
                    logger.Trace("Получен список всех заведений");
                    ests.Sort(new SortBySmth() 
                    { 
                        SortMode = "visits"
                    });
                    logger.Trace("Cписок всех заведений отсортирован по популярности");
                    foreach (var establishment in ests)
                    {
                        if (!user.Hidden.Contains(establishment)
                            && !user.Favourite.Contains(establishment)
                            && !establishments.Contains(establishment))
                        {
                            establishments.Add(establishment);
                            logger.Info($"В список рекомендованных добавлено " +
                                $"заведение '{establishment.Name}'");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Настройка отображения dataGridView рекомендованных заведений: 
        /// отображение заголовков, цвет текста и фона
        /// </summary>
        private void SetdgvMayLike()
        {
            dgvMayLike.Columns[0].Visible = false;
            dgvMayLike.RowHeadersVisible = false;
            dgvMayLike.EnableHeadersVisualStyles = false;
            dgvMayLike.ColumnHeadersDefaultCellStyle.BackColor =
                    System.Drawing.Color.FromArgb(
                        ((int)(((byte)(247)))), 
                        ((int)(((byte)(246)))), 
                        ((int)(((byte)(227))))
                        );
            dgvMayLike.ColumnHeadersDefaultCellStyle.Font = 
                new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
            dgvMayLike.ColumnHeadersDefaultCellStyle.ForeColor = 
                System.Drawing.Color.FromArgb(
                        ((int)(((byte)(103)))), 
                        ((int)(((byte)(72)))), 
                        ((int)(((byte)(49))))
                        );
            for (int i = 0; i < dgvMayLike.Rows.Count; i++)
            {
                dgvMayLike.Rows[i].DefaultCellStyle.BackColor =
                    System.Drawing.Color.FromArgb(
                        ((int)(((byte)(247)))), 
                        ((int)(((byte)(246)))), 
                        ((int)(((byte)(227))))
                        );
                dgvMayLike.Rows[i].DefaultCellStyle.ForeColor = 
                    System.Drawing.Color.FromArgb(
                        ((int)(((byte)(103)))), 
                        ((int)(((byte)(72)))), 
                        ((int)(((byte)(49))))
                        );
                dgvMayLike.Rows[i].DefaultCellStyle.Font = 
                    new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, 
                    System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            logger.Info("Отображена форма аккаунта");
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
            logger.Info($"Отображена форма с информацией о заведении {id}");
            new InfoForm(id, this.userId, this).Show();
        }

        private void checkBoxFavorite_CheckedChanged(object sender, EventArgs e)
        {
            logger.Info("datagridview всех заведений отсортирован по избранным");
            LoaddgvEstablishments(this.checkBoxFavorite.Checked);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Info("Форма Main закрыта");
            var count = Application.OpenForms.Count;
            for (int i = 1; i < count; i++)
            {
                logger.Info($"Закрыта форма {Application.OpenForms[1].Name}");
                Application.OpenForms[1].Close();
            }
            var form1 = Application.OpenForms[0];
            logger.Info("Открыта первая форма");
            form1.Show();            
        }

        private void dgvMayLike_DoubleClick(object sender, EventArgs e)
        {
            ShowInfoForm((Guid)this.dgvMayLike.CurrentRow.Cells[0].Value);
        }

        private void radioBtnSortByName_CheckedChanged(object sender, EventArgs e)
        {
            this.sortMode = "name";
            logger.Info("Ввызвана сортировка по названию");
            LoaddgvEstablishments(this.checkBoxFavorite.Checked);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.sortMode = "type";
            logger.Info("Ввызвана сортировка по типу");
            LoaddgvEstablishments(this.checkBoxFavorite.Checked);
        }

        private void radioBtnSortByRating_CheckedChanged(object sender, EventArgs e)
        {
            this.sortMode = "rating";
            logger.Info("Ввызвана сортировка по рейтингу");
            LoaddgvEstablishments(this.checkBoxFavorite.Checked);
        }

        private void radioBtnSortByVisits_CheckedChanged(object sender, EventArgs e)
        {
            this.sortMode = "visits";
            logger.Info("Ввызвана сортировка по популярности");
            LoaddgvEstablishments(this.checkBoxFavorite.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFDEstablishmentsFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            this.fileName = openFDEstablishmentsFile.FileName;
        }
    }
}