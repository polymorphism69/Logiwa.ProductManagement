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

        private void button1_Click(object sender, EventArgs e)
        {
            ProductManagement productManagement = new ProductManagement();
            productManagement.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryManagement categoryManagement = new CategoryManagement();
            categoryManagement.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListingProducts listingProducts = new ListingProducts();
            listingProducts.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListingCategories listingCategories = new ListingCategories();
            listingCategories.ShowDialog(); 
        }
    }
}
