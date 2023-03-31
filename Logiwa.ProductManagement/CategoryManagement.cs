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
            /*
             Delete product fonksiyonun aynısını buraya yazacağım
             
             */
        }
    }
}
