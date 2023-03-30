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
            //Product ekleme tamam, logiwa entities fonksiyon içinde tanımlı olarak kalsın
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            LogiwaEntities1 logiwa = new LogiwaEntities1();
            tblProduct product = new tblProduct();

            try
            {
                //Product Silme kısmında hata var çözülmesi gerekiyor

                /*
                 Product ID sistem tarafından otomatik olarak atandığı için şimdilik isimler üzerinden silme işlemi yapılıyor.
                 ID üzerinden olması için List Product'un hazırlanmış olması gerekiyor
                 */


                string productName = txtProductName.Text;
                var x = logiwa.tblProduct.Find(productName);
                logiwa.tblProduct.Remove(x);
                logiwa.SaveChanges();
                MessageBox.Show("Product Deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
