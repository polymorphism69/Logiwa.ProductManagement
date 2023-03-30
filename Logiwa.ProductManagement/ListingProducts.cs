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

        private void btnFind_Click(object sender, EventArgs e)
        {
            
            LogiwaEntities1 logiwa = new LogiwaEntities1();
            string productName = txtFindProduct.Text;

            var query = from item in logiwa.tblProduct
                        select new { item.PRODUCTID, item.PRODUCTNAME, item.PRODUCTCATEGORYID, item.PRODUCTSTOCK };
            dataGridView1.DataSource= query.ToList();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
