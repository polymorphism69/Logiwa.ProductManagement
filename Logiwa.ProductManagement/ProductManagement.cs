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

namespace Logiwa.ProductManagement
{
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"data source=DESKTOP-QAB9N31;initial catalog=Logiwa;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");


        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Product ID should be empty!");
            }
            else
            {
                ProductData productData = new ProductData();
                productData.ProductName = txtProductName.Text;
                productData.ProductCategoryId = Convert.ToInt32(txtProductCategoryId.Text);
                productData.InStock = Convert.ToInt32(txtProductStock.Text);

                LogiwaEntities1 logiwa = new LogiwaEntities1();
                tblProduct product = new tblProduct();
                product.PRODUCTNAME = productData.ProductName;
                product.PRODUCTCATEGORYID = productData.ProductCategoryId;
                product.PRODUCTSTOCK = productData.InStock;
                logiwa.tblProduct.Add(product);
                logiwa.SaveChanges();
                MessageBox.Show("Product Added!");
            }



        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LogiwaEntities1 db = new LogiwaEntities1();
                ProductData productData = new ProductData();
                productData.ProductId = Convert.ToInt32(textBox1.Text);
                int productid = productData.ProductId;
                var x = db.tblProduct.Find(productid);
                db.tblProduct.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Product Deleted!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
