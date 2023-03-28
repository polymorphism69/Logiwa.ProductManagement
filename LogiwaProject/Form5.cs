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

namespace LogiwaProject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-QAB9N31;Initial Catalog=Logiwa;Integrated Security=True");
                connection.Open();
                string query = "SELECT * FROM tblCategory WHERE CATEGORYID=@ID";

               
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
