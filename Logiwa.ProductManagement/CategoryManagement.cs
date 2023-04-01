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
using FluentValidation.Results;
using System.Data.SqlClient;
using System.Data.Entity;
using FluentValidation;

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

                
                // LogiwaEntities1 logiwaEntities1 = new LogiwaEntities1();

                 CategoryData categoryData = new CategoryData();
                 categoryData.CategoryName = txtCategoryName.Text;
            

                

                    CategoryValid valid = new CategoryValid();
                ValidationResult result = valid.Validate(categoryData);
                IList<ValidationFailure> failures = result.Errors;
                if (!result.IsValid)
                {

                    foreach (ValidationFailure failure in failures)
                    {
                        MessageBox.Show(failure.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        LogiwaEntities1 db = new LogiwaEntities1();
                        tblCategory category = new tblCategory();
                        category.CATEGORYNAME = categoryData.CategoryName;

                        db.tblCategory.Add(category);
                        db.SaveChanges();
                        MessageBox.Show("Category Added!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);

                    }
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
Kategori silme yaparken kontrol etme kısmı tamam, aynı işlemi bu sefer kategori adına bakarak ekleme kısmında yazacağım

*/


            LogiwaEntities1 db = new LogiwaEntities1();
            var CategoryID = Convert.ToInt32(textBox1.Text);
            var category = db.tblCategory.FirstOrDefault(x=> x.CATEGORYID == CategoryID);
            

            if (category == null)
            {
                MessageBox.Show("This category does not exist!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.tblCategory.Remove(category);
                db.SaveChanges();
                MessageBox.Show("Success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            


        }
    }
}
