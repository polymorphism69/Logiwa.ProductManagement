using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logiwa.ProductManagement
{
    public partial class ProductUpdate : Form
    {
        public ProductUpdate()
        {
            InitializeComponent();

        }

        LogiwaEntities1 db = new LogiwaEntities1();
        public void Delete()
        {
            ListingProducts form = new ListingProducts();
            int productid = Convert.ToInt32(label3.Text);
            var x = db.tblProduct.Where(y => y.PRODUCTID == productid)
                .Select(y => y.PRODUCTID)
                .FirstOrDefault();
            var z = db.tblProduct.Find(x);
            db.tblProduct.Remove(z);
            MessageBox.Show("Product removed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.SaveChanges();
            this.Close();
            form.ShowDialog();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();

        }


        public void Update()
        {
            //Update product
            ListingProducts form = new ListingProducts();

            var z = updatecombo.ValueMember;
            var x = db.tblCategory.Where(c => c.CATEGORYNAME == z)
                .Select(c => c.CATEGORYID)
                .FirstOrDefault();



            int productid = Convert.ToInt32(label3.Text);
            var product = db.tblProduct.SingleOrDefault(p => p.PRODUCTID == productid);
            product.PRODUCTNAME = txtProductName.Text;
            product.PRODUCTCATEGORYID = x;
            product.PRODUCTSTOCK = Convert.ToInt32(txtProductStock.Text);





            db.SaveChanges();
            MessageBox.Show("Updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListingProducts listingProducts = new ListingProducts();
            //SQL'DE GÜNCELLEME OLUYOR AMA DATAGRİD'E YANSIMIYOR BUNU ARAŞTIRMAM LAZIM
            this.Close();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void ProductUpdate_Load(object sender, EventArgs e)
        {
            LoadMethod();

        }
        //FORMLAR ARASI GEÇİŞTE FORM YOK ETME
        //DELEGATE 
        //FORMDAN FORMA BİLGİ GÖNDERİP AKSİYON ALMA
        private void LoadMethod()
        {
            ProductData product = new ProductData();
            tblCategory tbl = new tblCategory();
            var productCategoryId = product.ProductCategoryId;
            var categories = db.tblCategory.ToList();
            var category = db.tblCategory.SingleOrDefault(c => c.CATEGORYID == productCategoryId);

            var CATEGORYID = product.ProductCategoryId;
            var categoryname = db.tblCategory.Where(c=>c.CATEGORYID == CATEGORYID)
            .Select(c=>c.CATEGORYNAME)
            .FirstOrDefault();
            updatecombo.SelectedValue = categoryname;
            updatecombo.DisplayMember = "CATEGORYNAME";
            updatecombo.ValueMember = "CATEGORYID";
            updatecombo.DataSource = categories;
            
        }
    }
}