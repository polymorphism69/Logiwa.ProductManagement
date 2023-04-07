using System;
using System.Data;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "PRODUCTID")
            {
                string productName = dataGridView1.Rows[e.RowIndex].Cells["PRODUCTNAME"].Value.ToString();

                ProductManagement form = new ProductManagement();

                form.txtProductName.Text = productName;

                form.Show();
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
