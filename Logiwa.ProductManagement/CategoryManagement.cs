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
                LogiwaEntities1 db = new LogiwaEntities1();
                var categoryname = txtCategoryName.Text;
                var category2 = db.tblCategory.FirstOrDefault(x => x.CATEGORYNAME == categoryname);
                if (category2 != null)
                {
                    MessageBox.Show("This category already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        tblCategory category = new tblCategory();
                        category.CATEGORYNAME = txtCategoryName.Text;
                        db.tblCategory.Add(category);
                        db.SaveChanges();
                        MessageBox.Show("Category added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            LogiwaEntities1 db = new LogiwaEntities1();
            CategoryData categoryData = new CategoryData();
            categoryData.CategoryName = txtCategoryName.Text;
            string categoryname = categoryData.CategoryName;
            var x = db.tblCategory.Find(categoryname);
            db.tblCategory.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Category deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
