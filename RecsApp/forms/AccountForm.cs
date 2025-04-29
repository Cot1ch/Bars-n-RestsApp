using System.Linq;
using System.Windows.Forms;

namespace RecsApp
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();

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
            }
        }

        private void btnSaveChanges_Click(object sender, System.EventArgs e)
        {
            // написать сохранение в аккаунт


            this.Close();
        }

        private void AccountForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
