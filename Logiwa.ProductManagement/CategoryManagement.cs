using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
namespace Logiwa.ProductManagement
{
    public partial class CategoryManagement : Form
    {
        public CategoryManagement()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            try
            {
                LogiwaEntities1 db = new LogiwaEntities1();
                tblCategory category = new tblCategory();
                category.CATEGORYNAME = txtCategoryName.Text;
                db.tblCategory.Add(category);
                db.SaveChanges();
                MessageBox.Show("Category Added!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {

                /*
                 Product ID sistem tarafından otomatik olarak atandığı için şimdilik isimler üzerinden silme işlemi yapılıyor.
                 ID üzerinden olması için List Category'nin hazırlanmış olması gerekiyor
                 */


                /*
                 Product Class'ı ve FluentValidation paketi yüklendikten sonra tekrar düzenleme yapılacak
                 
                 */

                LogiwaEntities1 logiwa = new LogiwaEntities1();
                string categoryName = txtCategoryName.Text;
                var x = logiwa.tblProduct.Find(categoryName);
                logiwa.tblProduct.Remove(x);
                logiwa.SaveChanges();
                MessageBox.Show("Category Deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }
    }
}
