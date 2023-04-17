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
    public partial class ListingCategories : Form
    {
        public ListingCategories()
        {
            InitializeComponent();
        }

        LogiwaEntities1 logiwa = new LogiwaEntities1();

        private void btnFindCategory_Click(object sender, EventArgs e)
        {
            string categoryName = textBox1.Text;
            var query = from item in logiwa.tblCategory
                        select new { item.CATEGORYNAME, item.CATEGORYID };
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
             Bunu bütün listing methodlarına ekleyeceğim
            fluent validation eklediğim zaman güncelleme yapacağım
             */


            string arananKategori = textBox1.Text;
            var variables = from s in logiwa.tblCategory
                            select s;
            dataGridView1.DataSource = variables.ToList();
        }
        public void LoadMehtod()
        {
            LogiwaEntities1 db = new LogiwaEntities1();
            string name = textBox1.Text;
            var variables = from s in db.tblCategory
                            select s;
            dataGridView1.DataSource = variables.ToList();
            dataGridView1.Columns["CATEGORYID"].ReadOnly = true;


        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCategory form = new UpdateCategory();

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string categoryname = row.Cells["CATEGORYNAME"].Value.ToString();
            int categoryid = Convert.ToInt32(row.Cells["CATEGORYID"].Value);
            dataGridView1.Columns["CATEGORYID"].ReadOnly = true;

            form.txtCategoryUpdate.Text = categoryname;
            label3.Text = Convert.ToString(categoryid);
            form.label3.Text = Convert.ToString(categoryid);
            form.ShowDialog();
            

        }

        private void ListingCategories_Load(object sender, EventArgs e)
        {
            LoadMehtod();
        }
    }
}
