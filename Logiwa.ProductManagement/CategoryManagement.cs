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




            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Category ID should be empty!");
            }
            else
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

                    MessageBox.Show(ex.Message);

                }
            }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
           

            /*
             Burada bir if bloğu eğer kategori yoksa ne yapayım diye çalışacak eğer kategori yoksa hata verecek yoksa işlemleri yapacak
            aynı şey eklemede cateogry ve product için de geçerli

             
             
             */
            
            try
            {
                LogiwaEntities1 logiwa = new LogiwaEntities1();
                int categoryId = Convert.ToInt32(textBox1.Text);
                var x = logiwa.tblCategory.Find(categoryId);
                logiwa.tblCategory.Remove(x);
                logiwa.SaveChanges();
                MessageBox.Show("Category Deleted!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
