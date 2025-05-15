using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using NLog;
using ClosedXML.Excel;

namespace RecsApp
{
    /// <summary>
    /// Форма аккаунта с анкетой
    /// </summary>
    public partial class AccountForm : Form
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Идентификатор аккаунта пользователя
        /// </summary>
        private Guid userId;
        /// <summary>
        /// Ссылка на главную форму
        /// </summary>
        private MainForm mainForm;
        /// <summary>
        /// Конструктор AccountForm
        /// </summary>
        /// <param name="usId">Идентификатор пользователя</param>
        /// <param name="mainForm">Главная форма</param>
        public AccountForm(Guid usId, MainForm mainForm)
        {
            InitializeComponent();
            this.userId = usId;
            this.mainForm = mainForm;
            logger.Trace("Форма аккаунта загружена");
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            {
                if (string.IsNullOrEmpty(this.textBoxName.Text))
                {
                    MessageBox.Show(res.GetString("NameIsEmpty"), res.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(res.GetString("NameIsEmpty"));
                    return;
                }
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.Find(this.userId);
                logger.Trace($"Из базы данных получен пользователь {user.username}");

                var questionnaire = (
                    db.Questionnaires != null &&
                    db.Questionnaires.Count() != 0 &&                    
                    db.Questionnaires.First(quest => quest.user_Id == this.userId) != null) ?
                    db.Questionnaires
                    .Include(quest => quest.Est_Types)
                    .Include(quest => quest.Est_Categories)
                    .Include(quest => quest.Est_Foods)
                    .Include(quest => quest.Est_Average)
                    .First(quest => quest.user_Id == this.userId) :
                    new Questionnaire() { user_Id = this.userId };
                logger.Trace("Из базы данных получена анкета");

                questionnaire.Est_Types = new List<EstType>();
                foreach (var checkedItem in this.checkedListBoxType.CheckedItems)
                {
                    var types = (from type in db.Types
                                 where type.Title == checkedItem.ToString()
                                 select type).ToList();


                    questionnaire.Est_Types.Add(types.First());
                }
                logger.Info("Типы анкеты обновлены");

                questionnaire.Est_Categories = new List<EstCategory>();
                foreach (var checkedItem in this.checkedListBoxCategory.CheckedItems)
                {
                    var categories = (from category in db.Categories
                                      where category.Title == checkedItem.ToString()
                                      select category).ToList();

                    questionnaire.Est_Categories.Add(categories.First());
                }
                logger.Info("Категории анкеты обновлены");

                questionnaire.Est_Foods = new List<EstFood>();
                foreach (var checkedItem in this.checkedListBoxFood.CheckedItems)
                {
                    var foods = (from food in db.Foods
                                where food.Title == checkedItem.ToString()
                                select food).ToList();


                    questionnaire.Est_Foods.Add(foods.First());
                }
                logger.Info("Кухни анкеты обновлены");

                questionnaire.Est_Average = new List<EstAverageCheck>();
                foreach (var checkedItem in this.checkedListBoxAverage.CheckedItems)
                {
                    var Average = (from averagecheck in db.AverageChecks
                                    where averagecheck.Title == checkedItem.ToString()
                                    select averagecheck).ToList();

                    questionnaire.Est_Average.Add(Average.First());
                }
                logger.Info("Средние чеки анкеты обновлены");

                user.name = this.textBoxName.Text;
                logger.Info($"Имя пользователя обновлено -> {user.name}");
                mainForm.isRatingEqualsFive = this.checkBoxRating.Checked;
                db.Entry(questionnaire).State = EntityState.Modified;
                db.SaveChanges();
                logger.Info("База данных обновлена");
            }
            logger.Info("Главная форма обновлена");
            mainForm.LoadForm();
            this.Close();
            logger.Trace("Форма закрыта");
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\Resources\\resources.resx"))
            using (var db = new AppDbContext())
            {
                foreach (var item in db.Types.ToList())
                {
                    this.checkedListBoxType.Items.Add(item.Title);
                }
                logger.Info("Чекбокслисты типов заполнены");
                foreach (var item in db.Categories.ToList())
                {
                    this.checkedListBoxCategory.Items.Add(item.Title);
                }
                logger.Info("Чекбокслисты категорий заполнены");
                foreach (var item in db.Foods.ToList())
                {
                    this.checkedListBoxFood.Items.Add(item.Title);
                }
                logger.Info("Чекбокслисты кухонь заполнены");
                foreach (var item in db.AverageChecks.ToList())
                {
                    this.checkedListBoxAverage.Items.Add(item.Title);
                }
                logger.Info("Чекбокслисты средних чеков заполнены");

                if (db.Users.Find(userId) == null)
                {
                    MessageBox.Show(res.GetString("AccessDenied"), res.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(res.GetString("AccessDenied"));
                    this.Close();
                    return;
                }
                var user = db.Users.Find(userId);
                logger.Trace($"Из базы данных получен пользователь {user.username}");
                var questionnaire = db.Questionnaires
                    .Include(quest => quest.Est_Types)
                    .Include(quest => quest.Est_Categories)
                    .Include(quest => quest.Est_Foods)
                    .Include(quest => quest.Est_Average)
                    .First(quest => quest.User.user_Id == this.userId);
                logger.Trace($"Из базы данных получена анкета");

                this.textBoxName.Text = user.name;
                logger.Trace($"Имя пользователя отображено");
                this.textBoxLogin.Text = user.username;
                logger.Trace($"Логин пользователя отображен");

                if (questionnaire != null)
                {
                    foreach (var type in questionnaire.Est_Types)
                    {
                        checkedListBoxType.SetItemChecked(
                            this.checkedListBoxType.Items.IndexOf(type.Title), true);
                    }
                    logger.Info("Чекбокслисты типов обновлены");

                    foreach (var cat in questionnaire.Est_Categories)
                    {
                        checkedListBoxCategory.SetItemChecked(
                            this.checkedListBoxCategory.Items.IndexOf(cat.Title), true);
                    }
                    logger.Info("Чекбокслисты категорий обновлены");

                    foreach (var food in questionnaire.Est_Foods)
                    {
                        checkedListBoxFood.SetItemChecked(
                            this.checkedListBoxFood.Items.IndexOf(food.Title), true);
                    }
                    logger.Info("Чекбокслисты кухонь обновлены");

                    foreach (var average in questionnaire.Est_Average)
                    {
                        checkedListBoxAverage.SetItemChecked(
                            this.checkedListBoxAverage.Items.IndexOf(average.Title), true);
                    }
                    logger.Info("Чекбокслисты средних чеков обновлены");
                }

                this.Text = res.GetString("labelAccountText");
                this.labelName.Text = res.GetString("labelNameText");
                this.labelLogin.Text = res.GetString("labelLoginText");
                this.labelCategory.Text = res.GetString("labelCategoryText");
                this.labelType.Text = res.GetString("labelTypeText");
                this.buttonAccExit.Text = res.GetString("buttonAccExitText");
                this.btnSaveChanges.Text = res.GetString("btnSaveChangesText");
                this.labelAccount.Text = res.GetString("labelAccountText");
                this.labelFood.Text = res.GetString("labelFoodText");
                this.labelAverage.Text = res.GetString("labelAverageText");
                this.checkBoxRating.Text = res.GetString("checkBoxRatingText");

                logger.Info("Локализация выполнена");
            }
        }
        private void buttonAccExit_Click(object sender, EventArgs e)
        {
            this.userId = Guid.Empty;
            this.mainForm.userId = Guid.Empty;
            this.mainForm.Close();
            logger.Info("Форма очищена, аккаунт очищен");
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel файлы (*.xlsx)|*.xlsx",
                FileName = $"Отчет {DateTime.Now.ToShortDateString()}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users
                        .Include(us => us.Favourite)
                        .First(u => u.user_Id == this.userId);
                    var questionnaire = db.Questionnaires
                    .Include(quest => quest.Est_Types)
                    .Include(quest => quest.Est_Categories)
                    .Include(quest => quest.Est_Foods)
                    .Include(quest => quest.Est_Average)
                    .First(quest => quest.User.user_Id == this.userId);

                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден.");
                        return;
                    }

                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Отчет");

                    worksheet.Cell(1, 1).Value = "Логин";
                    worksheet.Cell(1, 2).Value = "Типы";
                    worksheet.Cell(1, 3).Value = "Категории";
                    worksheet.Cell(1, 4).Value = "Кухни";
                    worksheet.Cell(1, 5).Value = "Средний чек";
                    worksheet.Cell(1, 6).Value = "Избранные заведения";

                    worksheet.Row(1).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Row(1).Style.Font.Bold = true;

                    worksheet.Cell(2, 1).Value = user.username;

                    var types = string.Empty;
                    if (user.Questionnaire != null && questionnaire.Est_Types != null)
                    {
                        foreach (var type in questionnaire.Est_Types)
                        {
                            if (types != string.Empty) 
                            { 
                                types += ", "; 
                            }
                            types += type.Title;
                        }
                    }                    
                    worksheet.Cell(2, 2).Value = types;

                    var categories = string.Empty;
                    if (user.Questionnaire != null && questionnaire.Est_Categories != null)
                    {
                        foreach (var category in questionnaire.Est_Categories)
                        {
                            if (categories != string.Empty) 
                            { 
                                categories += ", "; 
                            }
                            categories += category.Title;
                        }
                    }
                    worksheet.Cell(2, 3).Value = categories;

                    var foods = string.Empty;
                    if (user.Questionnaire != null && questionnaire.Est_Foods != null)
                    {
                        foreach (var food in questionnaire.Est_Foods)
                        {
                            if (foods != string.Empty) 
                            { 
                                foods += ", "; 
                            }
                            foods += food.Title;
                        }
                    }
                    worksheet.Cell(2, 4).Value = foods;

                    var averageCheck = string.Empty;
                    if (user.Questionnaire != null && questionnaire.Est_Average != null)
                    {
                        foreach (var avg in questionnaire.Est_Average)
                        {
                            if (averageCheck != string.Empty)
                            {
                                averageCheck += ", ";
                            }
                            averageCheck += avg.Title;
                        }
                    }
                    worksheet.Cell(2, 5).Value = averageCheck;

                    var favorites = string.Empty;
                    if (user.Favourite != null)
                    {
                        foreach (var favorite in user.Favourite)
                        {
                            if (favorites != string.Empty)
                            {
                                favorites += ", ";
                            }
                            favorites += favorite.Name;
                        }
                    }
                    worksheet.Cell(2, 6).Value = favorites;
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Отчёт сохранён!");
                }
            }
        }
    }
}
