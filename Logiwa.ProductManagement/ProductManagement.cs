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
using FluentValidation.Results;
using System.Data.Entity;

namespace Logiwa.ProductManagement
{
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            LogiwaEntities1 db = new LogiwaEntities1();
            var categoryName = comboBox1.SelectedValue;


            ProductData productData = new ProductData();
            productData.ProductName = txtProductName.Text;
            productData.ProductCategoryId = Convert.ToInt32(categoryName);
            productData.InStock = Convert.ToInt32(txtProductStock.Text);

            // geçerlilik kontrolü ve ekleme işlemi
            ProductValid valid = new ProductValid();
            ValidationResult result = valid.Validate(productData);
            IList<ValidationFailure> failures = result.Errors;
            if (!result.IsValid)
            {
                foreach (ValidationFailure failure in failures)
                {
                    MessageBox.Show(failure.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LogiwaEntities1 logiwa = new LogiwaEntities1();
                var productname = productData.ProductName;
                var product2 = logiwa.tblProduct.FirstOrDefault(p => p.PRODUCTNAME == productname);
                if (product2 != null)
                {
                    MessageBox.Show("This product already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tblProduct product3 = new tblProduct();
                    product3.PRODUCTNAME = productData.ProductName;
                    product3.PRODUCTCATEGORYID = productData.ProductCategoryId;
                    product3.PRODUCTSTOCK = productData.InStock;
                    logiwa.tblProduct.Add(product3);
                    logiwa.SaveChanges();
                    MessageBox.Show("Product added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label3.Text = Convert.ToString(product3.PRODUCTID);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            /*
             Algoritma:
            Product name'yi bul 
            product name'den product id'sini al 
            remove at
             
             */


            LogiwaEntities1 db = new LogiwaEntities1();
            ProductData productData = new ProductData();
            productData.ProductName = txtProductName.Text;
            string productName = productData.ProductName;
            var x = db.tblProduct.Where(p => p.PRODUCTNAME == productName)
                .Select(p => p.PRODUCTID)
                .FirstOrDefault();
            label3.Text = Convert.ToString(x);
            label3.Show();
        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {
            label3.Hide();
            LogiwaEntities1 db = new LogiwaEntities1();
            var categories = db.tblCategory.ToList();
            comboBox1.DataSource = categories;
            comboBox1.ValueMember = "CATEGORYID";
            comboBox1.DisplayMember = "CATEGORYNAME";

        }
    }
}
