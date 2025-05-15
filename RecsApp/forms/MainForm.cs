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
        /// <summary>
        /// Логгер
        /// </summary>
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
        /// <summary>
        /// Путь к файлу по умолчанию
        /// </summary>
        private string defFileName = $"{Directory.GetCurrentDirectory()}" +
                $"..\\..\\..\\docs\\Списки заведений, типов, категорий.xlsx";
        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        /// <param name="usId">Идентификатор пользователя</param>
        public MainForm(Guid usId)
        {
            InitializeComponent();

            userId = usId;
            this.fileName = this.defFileName;
            if (this.fileName != this.defFileName)
            {
                using (var res = new ResXResourceSet(
                    $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
                {
                    MessageBox.Show(res.GetString("LoadFile") + $": {this.fileName}",
                    res.GetString("LoadFile"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                    (from us in db.Users.Include(us => us.Favourite)
                     where us.user_Id == userId
                     select us).First();

                if (user.username == "adminnn")
                {
                    this.btnChangeFile.Visible = true;
                    logger.Info("Кнопка для смены файла сделана видимой");
                }
            }

            LoadForm();
            logger.Trace("dataGridView's заполнены");
            Application.OpenForms[0].Hide();
            logger.Trace("Форма FirstForm скрыта");

            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
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
                    (from us in db.Users
                     .Include(us => us.Favourite)
                     .Include(us => us.Hidden)
                     where us.user_Id == userId
                     select us).First();
                logger.Info($"Получен пользователь {user.username}");

                var ests = db.Establishments
                    .Include(establishment => establishment.Type)
                    .Include(establishment => establishment.Categories)
                    .Include(establishment => establishment.Foods)
                    .Include(establishment => establishment.Average).ToList();
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
                        var types = questionnaire.Est_Types
                            .Select(type => type.Id).ToList();
                        var categories = questionnaire.Est_Categories
                            .Select(category => category.Id).ToList();
                        var foods = questionnaire.Est_Foods
                            .Select(food => food.Id).ToList();
                        var average = questionnaire.Est_Average
                            .Select(averageCheck => averageCheck.Id).ToList();

                        if (types != null && types.Count != 0)
                        {
                            ests = (
                                from establishment in ests
                                where types.Contains(establishment.Type.Id)
                                select establishment).ToList();
                            logger.Info("Заведения отфильтрованы по типу");
                        }
                        if (categories != null && categories.Count != 0)
                        {
                            ests = (
                                from establishment in ests
                                where establishment.Categories.Select(category => category.Id)
                                    .Any(c => categories.Contains(c))
                                select establishment).ToList();
                            logger.Info("Заведения отфильтрованы по категориям");
                        }
                        if (foods != null && foods.Count != 0)
                        {
                            ests = (
                                from establishment in ests
                                where establishment.Foods.Select(food => food.Id)
                                .Any(c => foods.Contains(c))
                                select establishment).ToList();
                            logger.Info("Заведения отфильтрованы по кухне");
                        }
                        if (average != null && average.Count != 0)
                        {
                            ests = (
                                from establishment in ests
                                where average.Contains(establishment.Average.Id)
                                select establishment).ToList();
                            logger.Info("Заведения отфильтрованы по среднему чеку");
                        }
                    }
                }
                if (showOnlyFavourite)
                {
                    ests = (
                        from establishment in ests
                        where user.Favourite.Contains(establishment)
                        select establishment).ToList();
                    logger.Info("Выбраны только избранные");
                }
                if (isRatingEqualsFive)
                {
                    ests = (
                        from establishment in ests
                        where establishment.Rating == 5.0
                        select establishment).ToList();
                    logger.Info("Выбраны только заведения с рейтингом 5.0");
                }
                ests = (
                    from establishment in ests
                    where !user.Hidden.Contains(establishment)
                    select establishment).ToList();

                ests.Sort(new SortBySmth()
                {
                    SortMode = this.sortMode
                });
                logger.Info($"Заведения отсортированы, sortMode={sortMode}");

                var finalEsts = from establishment in ests
                                join type in db.Types on establishment.Type equals type
                                select new
                                {
                                    establishment.Id,
                                    Название = establishment.Name,
                                    Тип = type.Title,
                                    Рейтинг = establishment.Rating
                                };

                if (!finalEsts.Any())
                {
                    using (var res = new ResXResourceSet(
                        $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
                    {
                        MessageBox.Show(res.GetString("EmptyEstList"), res.GetString("EmptyEsts"),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                }
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
            dgvEstablishments.Columns[0].Visible = false;
            dgvEstablishments.RowHeadersVisible = false;
            dgvEstablishments.EnableHeadersVisualStyles = false;
        }
        /// <summary>
        /// Загрузка dataGridView с рекомендованными заведениями
        /// </summary>
        private void LoaddgvMayLike()
        {
            using (var db = new AppDbContext())
            {
                var user =
                    (from us in db.Users
                     .Include(us => us.Favourite)
                     .Include(us => us.Hidden)                     
                     where us.user_Id == userId
                     select us).First();
                logger.Info($"Получен пользователь {user.username}");
                var ests = db.Establishments
                    .Include(establishment => establishment.Type)
                    .Include(establishment => establishment.Categories)
                    .Include(establishment => establishment.Foods)
                    .Include(establishment => establishment.Average)
                    .ToList();
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
                    foreach (var establishment in ests)
                    {
                        foreach (var sim in establishment.Similar.Split(';'))
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
                        from establishment in ests
                        where user.Favourite.Contains(establishment)
                        select establishment).ToList();
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
                    from establishment in db.Establishments
                    where simEsts.Contains(establishment.Name)
                    select establishment).ToList();
                logger.Info("Список рекомендованных заведений получен");

                LoadRecsList(Ests, user);

                Ests.Sort(new SortBySmth() 
                { 
                    SortMode = "visits" 
                });
                logger.Info("Список рекомендованных заведений отсортирован по популярности");

                var finalEsts = (
                    from establishment in Ests.Take(10)
                    select new 
                    { 
                        establishment.Id,
                        establishment.Name,
                        establishment.Rating 
                    }).ToList();

                dgvMayLike.DataSource = finalEsts;
                logger.Info("datagridview заполнен");
            }
            SetdgvMayLike();
            logger.Info("datagridview настроен");
        }
        /// <summary>
        /// Метод реализации алгоритма заполнения списка, если в нем меньше 10 элементов
        /// </summary>
        /// <param name="establishments"></param>
        /// <param name="user"></param>
        private void LoadRecsList(List<Establishment> establishments, User user)
        {
            establishments = (
                    from establishment in establishments
                    where !user.Hidden.Contains(establishment) 
                    && !user.Favourite.Contains(establishment)
                    select establishment).ToList();
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
        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            if (openFDEstablishmentsFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            this.fileName = openFDEstablishmentsFile.FileName;
        }
    }
}