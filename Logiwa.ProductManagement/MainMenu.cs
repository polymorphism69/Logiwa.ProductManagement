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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddDeleteProduct addDeleteProduct = new AddDeleteProduct();
            addDeleteProduct.ShowDialog();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddDeleteCategoruy addDeleteCategoruy = new AddDeleteCategoruy();
            addDeleteCategoruy.ShowDialog();
        }

        private void btnListProduct_Click(object sender, EventArgs e)
        {
            ListProductsForm listProductsForm = new ListProductsForm();
            listProductsForm.ShowDialog();
        }

        private void btnListCategories_Click(object sender, EventArgs e)
        {
            ListCategoriesForm listCategoriesForm = new ListCategoriesForm();
            listCategoriesForm.ShowDialog();
        }
    }
}
