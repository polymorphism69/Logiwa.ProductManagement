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
            /*
             AMAC:
                textboxlar boş olmadan dataları çek ve SQL'e yazdır 
            fluent validation kullan TAMAMDIR


             */
            try
            {
                string productname = Convert.ToString(textBox1.Text);
                int productId = Convert.ToInt32(textBox2.Text);
                int inStock = Convert.ToInt32(textBox3.Text);
                int productcategoryId = Convert.ToInt32(textBox4.Text);


               
                connection.Open();
                string query = "INSERT INTO tblProduct (PRODUCTNAME,PRODUCTID,PRODUCTSTOCK,PRODUCTCATEGORYID) VALUES (@PRODUCTNAME, @PRODUCTID,@PRODUCTSTOCK,@PRODUCTCATEGORYID)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PRODUCTNAME", productname);
                cmd.Parameters.AddWithValue("@PRODUCTID", productId);
                cmd.Parameters.AddWithValue("@PRODUCTSTOCK", inStock);
                cmd.Parameters.AddWithValue("@PRODUCTCATEGORYID", productcategoryId);



                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    MessageBox.Show("Added");

                }


                    
            }

            catch (Exception ex)
            {

                MessageBox.Show("error : " + ex);
            }
            finally {


                connection.Close();
            };


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
