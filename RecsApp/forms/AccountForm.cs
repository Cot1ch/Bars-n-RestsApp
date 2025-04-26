using System.Linq;
using System.Windows.Forms;

namespace RecsApp.forms
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
    }
}
