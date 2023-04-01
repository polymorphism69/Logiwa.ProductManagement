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
                productData.ProductCategoryId =     Convert.ToInt32(txtProductCategoryId.Text);
                productData.InStock = Convert.ToInt32(txtProductStock.Text);





                /*
                 HATA :
                Validation için ProductData'da stock ve id'yi string değer olarak tanımladık
                ama bu değerler integer
                ve bu değerleri boş geçersek uygulamada değil derleyicide hata veriyor
                bu hatayı çözmemiz gerek
                Durumu gelince abime anlatıp validation kısmında yardım isteyeceğim, şimdilik validaton olmadan devam edelim

                 
                 */

                //ProductValid valid = new ProductValid();
                //ValidationResult result = valid.Validate(productData);
                //IList<ValidationFailure> failures = result.Errors;
                //if (!result.IsValid)
                //{
                //    foreach (ValidationFailure failure in failures)
                //    {
                //        MessageBox.Show(failure.ErrorMessage,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
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
