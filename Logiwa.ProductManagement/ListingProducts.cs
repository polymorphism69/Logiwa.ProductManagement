using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Logiwa.ProductManagement
{
    public partial class ListingProducts : Form
    {
        public ListingProducts()
        {
            InitializeComponent();
        }

        LogiwaEntities1 logiwa = new LogiwaEntities1();
        private void btnFind_Click(object sender, EventArgs e)
        {
            string productName = txtFindProduct.Text;
            var query = from item in logiwa.tblProduct.Where(x => x.PRODUCTSTOCK > 0)
                        select new { item.PRODUCTID, item.PRODUCTNAME, item.PRODUCTCATEGORYID, item.PRODUCTSTOCK };
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Sadece satırın çift tıklanması durumunda işlem yapılır
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string productName = row.Cells["PRODUCTNAME"].Value.ToString();

                // Bağlantı dizesini tanımlayın ve veritabanı bağlantısını açın
                string connectionString = "Data Source=DESKTOP-QAB9N31;Initial Catalog=Logiwa;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Ürünü arayın ve ProductManagement formuna geçin
                    string query = "SELECT * FROM tblProduct WHERE PRODUCTNAME = @ProductName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int categoryId = (int)reader["PRODUCTCATEGORYID"];
                        bool inStock = (bool)reader["PRODUCTSTOCK"];

                        // Açık olan formu kapatın
                        this.Close();

                        // ProductManagement formuna geçin
                        ProductManagement form = new ProductManagement();
                        form.Show();

                        // txtName isimli textbox'a PRODUCTNAME değerini yazdırın
                        form.txtProductName.Text = productName;
                    }

                    reader.Close();
                }
            }
        }





        public void Method()
        {
            string arananUrun = txtFindProduct.Text;
            var variables = from s in logiwa.tblProduct
                            select s;
            dataGridView1.DataSource = variables.ToList();
            dataGridView1.Columns["PRODUCTID"].ReadOnly = true;
        }
        private void txtFindProduct_TextChanged(object sender, EventArgs e)
        {
            string arananUrun = txtFindProduct.Text;
            var variables = from s in logiwa.tblProduct
                            select s;
            dataGridView1.DataSource = variables.ToList();
        }

        private void ListingProducts_Load(object sender, EventArgs e)
        {
            Method();
        }
    }
}
