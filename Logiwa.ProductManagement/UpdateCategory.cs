using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logiwa.ProductManagement
{
    public partial class UpdateCategory : Form
    {
        public UpdateCategory()
        {
            InitializeComponent();
        }

        LogiwaEntities1 db = new LogiwaEntities1();
        private void btnDelete_Click(object sender, EventArgs e)
        {

            LogiwaEntities1 db  = new LogiwaEntities1();
            int categoryid = Convert.ToInt32(label3.Text);
            var x = db.tblCategory.Where(y=>y.CATEGORYID == categoryid)
                .Select(y=>y.CATEGORYID)
                .FirstOrDefault();
            var z = db.tblCategory.Find(x);
            db.tblCategory.Remove(z);
            MessageBox.Show("Category removed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.SaveChanges();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int categoryid = Convert.ToInt32(label3.Text);
            var category = db.tblCategory.SingleOrDefault(c => c.CATEGORYID == categoryid);
            category.CATEGORYNAME = txtCategoryUpdate.Text;
            db.SaveChanges();
            MessageBox.Show("Updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
