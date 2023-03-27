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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
          
            string query = "SELECT * FROM tblProduct WHERE PRODUCTID=@ID";
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-QAB9N31;Initial Catalog=Logiwa;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection );
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //verileri almak ve kaydetmek için  SQL Server arasında bir DataSet köprü görevi görür.
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
