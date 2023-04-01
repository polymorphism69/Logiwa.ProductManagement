using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation; 
namespace Logiwa.ProductManagement
{
    internal class ProductValid : AbstractValidator<ProductData>
    {
        public ProductValid() {
            Regex regexProductName = new Regex(@"^[a-zA-Z-']*$");
            Regex regexNumbers = new Regex(@"^[0-9' a-zA-Z- ]*$");

            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Product Name cannot be empty").Matches(regexProductName);
            RuleFor(x => x.InStock).NotNull().WithMessage("In stock cannot be empty!");
            RuleFor(x => x.ProductCategoryId).NotNull().NotEmpty().WithMessage("You should give category id");
            
        }
    }
}
