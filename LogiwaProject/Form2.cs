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
using FluentValidation;
using System.Data.SqlClient;
using FluentValidation.Results;

namespace LogiwaProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-QAB9N31;Initial Catalog=Logiwa;Integrated Security=True");





        private void button2_Click(object sender, EventArgs e)
        {




            Product product = new Product
            {

                ProductName = Convert.ToString(textBox1.Text),
                ProductID = Convert.ToInt32(textBox2.Text),
                ProductInStock = Convert.ToInt32(textBox3.Text),
                ProductCategoryId = Convert.ToInt32(textBox4.Text)

            };





            ProductValid rules = new ProductValid();
            ValidationResult result = rules.Validate(product);
            IList<ValidationFailure> fails = result.Errors;


            if (!result.IsValid)
            {
                foreach (ValidationFailure item in fails)
                {
                    MessageBox.Show(item.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                string query = "INSERT INTO tblProduct (PRODUCTNAME,PRODUCTID,PRODUCTSTOCK,PRODUCTCATEGORYID) VALUES (@PRODUCTNAME, @PRODUCTID,@PRODUCTSTOCK,@PRODUCTCATEGORYID)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PRODUCTNAME", product.ProductName);
                cmd.Parameters.AddWithValue("@PRODUCTID", product.ProductID);
                cmd.Parameters.AddWithValue("@PRODUCTSTOCK", product.ProductInStock);
                cmd.Parameters.AddWithValue("@PRODUCTCATEGORYID", product.ProductCategoryId);



                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    MessageBox.Show("Added");

                }


                connection.Close();
            }

          




        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(textBox2.Text);
                connection.Open();
                string query = "DELETE FROM tblProduct WHERE PRODUCTID=@PRODUCTID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PRODUCTID", productId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error : " + ex);
            }
            finally
            {
                connection.Close();
            };
        }

    }
}
