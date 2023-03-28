using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiwaProject
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductInStock { get; set; }
    }
}
