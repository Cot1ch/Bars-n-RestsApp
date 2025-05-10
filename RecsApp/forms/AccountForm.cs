using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections.Generic;

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
            if (string.IsNullOrEmpty(this.textBoxName.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }

            using (var db = new AppDbContext())
            {
                var user = (
                    from u in db.Users.
                    Include(u => u.est_types).Include(u => u.est_categories).
                    Include(u => u.est_foods).Include(u => u.est_Average)
                    where u.user_Id == userId
                    select u).First();

                user.est_types = new List<EstType>();
                foreach (var checkedItem in this.checkedListBoxType.CheckedItems)
                {
                    var types = (from t in db.Types
                                 where t.Title == checkedItem.ToString()
                                 select t).ToList();

                    if (types.Count != 0)
                    {
                        user.est_types.Add(types.First());                        
                    }
                }

                user.est_categories = new List<EstCategory>();
                foreach (var checkedItem in this.checkedListBoxCategory.CheckedItems)
                {
                    var categories = (from c in db.Categories
                                      where c.Title == checkedItem.ToString()
                                      select c).ToList();


                    user.est_categories.Add(categories.First());
                }

                user.est_foods = new List<EstFood>();
                foreach (var checkedItem in this.checkedListBoxFood.CheckedItems)
                {
                    var food = (from f in db.Foods
                                where f.Title == checkedItem.ToString()
                                select f).ToList();


                    user.est_foods.Add(food.First());
                }

                user.est_Average = new List<EstAverageCheck>();
                foreach (var checkedItem in this.checkedListBoxAverage.CheckedItems)
                {
                    var Average = (from ac in db.AverageChecks
                                    where ac.Title == checkedItem.ToString()
                                    select ac).ToList();

                    user.est_Average.Add(Average.First());
                }
                user.name = this.textBoxName.Text;
                mainForm.isRatingEqualsFive = this.checkBoxRating.Checked;
                db.SaveChanges();
            }
            mainForm.LoadForm();
            this.Close();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Ошибка! Данные аккаунта пусты");
                    this.Close();
                    return;
                }
                var user = db.Users.Find(userId);
                this.textBoxName.Text = user.name;
                this.textBox2.Text = user.username;

                if (user.est_types == null)
                {
                    return;
                }

                foreach (var type in user.est_types)
                {
                    checkedListBoxType.SetItemChecked(
                        this.checkedListBoxType.Items.IndexOf(type.Title), true);
                }
                foreach (var cat in user.est_categories)
                {
                    checkedListBoxCategory.SetItemChecked(
                        this.checkedListBoxCategory.Items.IndexOf(cat.Title), true);
                }
                foreach (var food in user.est_foods)
                {
                    checkedListBoxFood.SetItemChecked(
                        this.checkedListBoxFood.Items.IndexOf(food.Title), true);
                }
                foreach (var average in user.est_Average)
                {
                    checkedListBoxAverage.SetItemChecked(
                        this.checkedListBoxAverage.Items.IndexOf(average.Title), true);
                }
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
