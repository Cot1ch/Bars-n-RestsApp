using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO;
using System.Resources;

namespace RecsApp
{
    /// <summary>
    /// Форма аккаунта с анкетой
    /// </summary>
    public partial class AccountForm : Form
    {
        /// <summary>
        /// Идентификатор аккаунта пользователя
        /// </summary>
        private Guid userId;
        /// <summary>
        /// Ссылка на главную форму
        /// </summary>
        private MainForm mainForm;
        public AccountForm(Guid usId, MainForm mainForm)
        {
            InitializeComponent();
            this.userId = usId;
            this.mainForm = mainForm;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\forms\\AccountForm.resx"))
            {
                if (string.IsNullOrEmpty(this.textBoxName.Text))
                {
                    MessageBox.Show(res.GetString("NameIsEmpty"), res.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.Find(this.userId);

                var questionnaire = (
                    db.Questionnaires.Count() != 0 &&
                    db.Questionnaires.First(quest => quest.User.user_Id == this.userId) != null) ?
                    db.Questionnaires
                    .Include(quest => quest.Est_Types)
                    .Include(quest => quest.Est_Categories)
                    .Include(quest => quest.Est_Foods)
                    .Include(quest => quest.Est_Average)
                    .First(quest => quest.User.user_Id == this.userId) :
                    new Questionnaire() { user_Id = this.userId };

                questionnaire.Est_Types = new List<EstType>();
                foreach (var checkedItem in this.checkedListBoxType.CheckedItems)
                {
                    var types = (from t in db.Types
                                 where t.Title == checkedItem.ToString()
                                 select t).ToList();


                    questionnaire.Est_Types.Add(types.First());
                }

                questionnaire.Est_Categories = new List<EstCategory>();
                foreach (var checkedItem in this.checkedListBoxCategory.CheckedItems)
                {
                    var categories = (from c in db.Categories
                                      where c.Title == checkedItem.ToString()
                                      select c).ToList();

                    questionnaire.Est_Categories.Add(categories.First());
                }

                questionnaire.Est_Foods = new List<EstFood>();
                foreach (var checkedItem in this.checkedListBoxFood.CheckedItems)
                {
                    var food = (from f in db.Foods
                                where f.Title == checkedItem.ToString()
                                select f).ToList();


                    questionnaire.Est_Foods.Add(food.First());
                }

                questionnaire.Est_Average = new List<EstAverageCheck>();
                foreach (var checkedItem in this.checkedListBoxAverage.CheckedItems)
                {
                    var Average = (from ac in db.AverageChecks
                                    where ac.Title == checkedItem.ToString()
                                    select ac).ToList();

                    questionnaire.Est_Average.Add(Average.First());
                }

                user.name = this.textBoxName.Text;
                mainForm.isRatingEqualsFive = this.checkBoxRating.Checked;
                db.Entry(questionnaire).State = EntityState.Modified;
                db.SaveChanges();
            }
            mainForm.LoadForm();
            this.Close();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            using (var res = new ResXResourceSet(
                $"{Directory.GetCurrentDirectory()}..\\..\\..\\forms\\AccountForm.resx"))
            using (var db = new AppDbContext())
            {
                foreach (var item in db.Types.ToList())
                {
                    this.checkedListBoxType.Items.Add(item.Title);
                }
                foreach (var item in db.Categories.ToList())
                {
                    this.checkedListBoxCategory.Items.Add(item.Title);
                }
                foreach (var item in db.Foods.ToList())
                {
                    this.checkedListBoxFood.Items.Add(item.Title);
                }
                foreach (var item in db.AverageChecks.ToList())
                {
                    this.checkedListBoxAverage.Items.Add(item.Title);
                }
 
                if (db.Users.Find(userId) == null)
                {
                    MessageBox.Show(res.GetString("AccessDenied"), res.GetString("Error"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                var user = db.Users.Find(userId);
                var questionnaire = db.Questionnaires
                    .Include(quest => quest.Est_Types)
                    .Include(quest => quest.Est_Categories)
                    .Include(quest => quest.Est_Foods)
                    .Include(quest => quest.Est_Average)
                    .First(quest => quest.User.user_Id == this.userId);

                this.textBoxName.Text = user.name;
                this.textBoxLogin.Text = user.username;

                if (questionnaire != null)
                {
                    foreach (var type in questionnaire.Est_Types)
                    {
                        checkedListBoxType.SetItemChecked(
                            this.checkedListBoxType.Items.IndexOf(type.Title), true);
                    }
                    foreach (var cat in questionnaire.Est_Categories)
                    {
                        checkedListBoxCategory.SetItemChecked(
                            this.checkedListBoxCategory.Items.IndexOf(cat.Title), true);
                    }
                    foreach (var food in questionnaire.Est_Foods)
                    {
                        checkedListBoxFood.SetItemChecked(
                            this.checkedListBoxFood.Items.IndexOf(food.Title), true);
                    }
                    foreach (var average in questionnaire.Est_Average)
                    {
                        checkedListBoxAverage.SetItemChecked(
                            this.checkedListBoxAverage.Items.IndexOf(average.Title), true);
                    }
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
            }
        }
        private void buttonAccExit_Click(object sender, EventArgs e)
        {
            this.userId = Guid.Empty;
            this.mainForm.userId = Guid.Empty;
            this.mainForm.Close();
        }
    }
}
