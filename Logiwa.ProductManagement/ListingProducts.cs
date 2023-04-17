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
        ProductUpdate form = new ProductUpdate();
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
            
            ListingProducts list = new ListingProducts();
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string productName = row.Cells["PRODUCTNAME"].Value.ToString();
            string categoryId = row.Cells["PRODUCTCATEGORYID"].Value.ToString();
            int inStock = Convert.ToInt32(row.Cells["PRODUCTSTOCK"].Value);
            int productID = Convert.ToInt32(row.Cells["PRODUCTID"].Value);
            
           
            form.txtProductName.Text = productName;
            //Category id'yi de çekmesi lazım çektikten sonra gösterecek ve ek olarak da 
            //diğer kategorileri de gösterecek ki update işlemini yapabileyim
            //update işlemini id üzerinden yapacz
             form.txtProductStock.Text = inStock.ToString();
            form.txtProductName.Text = productName;
            form.label3.Text = Convert.ToString(productID);
            form.ShowDialog();
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
