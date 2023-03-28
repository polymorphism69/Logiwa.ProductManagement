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
using System.Data.SqlClient;
using FluentValidation;
using FluentValidation.Results;

namespace LogiwaProject
{
    public partial class Form3 : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-QAB9N31;Initial Catalog=Logiwa;Integrated Security=True");

        public Form3()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            string categoryName = txtName.Text;
            int categoryId = Convert.ToInt32(txtId.Text);


        Category category = new Category
        {

            CategoryID= categoryId,
            CategoryName= categoryName,

        };
        CategoryValid categoryValid = new CategoryValid();
        ValidationResult result= categoryValid.Validate(category);
        IList<ValidationFailure> failures= new List<ValidationFailure>();


            if (!result.IsValid)
            {
                foreach (ValidationFailure item in failures)
                {
                    MessageBox.Show(item.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                connection.Open();

                            string query = "INSERT INTO tblCategory (CATEGORYNAME,CATEGORYID) VALUES (@CATEGORYNAME,@CATEGORYID)";

                             SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@CATEGORYNAME", categoryName);
                            cmd.Parameters.AddWithValue("@CATEGORYID", categoryId);
                             int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {

                MessageBox.Show("Category Added!");
                }
                connection.Close();

            }


        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                int categoryId = Convert.ToInt32(txtId.Text);

                string Query = "DELETE FROM tblCategory WHERE CATEGORYID=@CATEGORYID";
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@CATEGORYID", categoryId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Category Deleted!");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
