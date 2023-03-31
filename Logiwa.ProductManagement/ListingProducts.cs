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

            var query = from item in logiwa.tblProduct
                        select new { item.PRODUCTID, item.PRODUCTNAME, item.PRODUCTCATEGORYID, item.PRODUCTSTOCK };
            dataGridView1.DataSource= query.ToList();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFindProduct_TextChanged(object sender, EventArgs e)
        {
            string arananUrun = txtFindProduct.Text;
            var variables = from s in logiwa.tblProduct
                            select s;
            dataGridView1.DataSource = variables.ToList();
        }
    }
}
