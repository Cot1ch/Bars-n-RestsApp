using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RecsApp
{
    public partial class AccountForm : Form
    {
        private Guid userId;
        private MainForm mainForm;
        public AccountForm(Guid usId, MainForm mainForm)
        {
            InitializeComponent();
            userId = usId;
            this.mainForm = mainForm;

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
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            {

                var user = db.Users.FirstOrDefault();
                foreach (var checkedItem in this.checkedListBoxType.CheckedItems)
                {
                    var types = (from t in db.Types
                                 where t.Title == checkedItem.ToString()
                                 select t).ToList();

                    if (types.Count != 0)
                    {
                        user.type_id.Add(types[0].Id);                        
                    }
                }
                db.SaveChanges();
            }

            this.Close();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            using (var db = new AppDbContext())
            { 
                if (db.Users.Find(userId) == null)
                {
                    MessageBox.Show("Ошибка! Данные аккаунта пусты");
                    this.Close();
                    return;
                }
                User user = db.Users.Find(userId);
                this.textBoxName.Text = user.name;
                this.textBox2.Text = user.username;

                if (user.type_id == null)
                {
                    return;
                }
                
                foreach (var type in user.type_id.ToList())
                {
                    checkedListBoxType.SetItemChecked(this.checkedListBoxType.Items.IndexOf(db.Types.Find(type).Title), true);
                }
            }
        }
    }
}
