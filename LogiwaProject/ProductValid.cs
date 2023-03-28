using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
namespace LogiwaProject
{
    internal class ProductValid:AbstractValidator<Product>

    {
        public ProductValid() {


           Regex regex = new Regex("^[0-9]+$");

            RuleFor(x => x.ProductCategoryId).NotEmpty().WithMessage("Please enter a category id for product!") ;
            RuleFor(x => x.ProductID).NotEmpty().WithMessage("Please enter a id for product!");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("please enter a product namw!");
            RuleFor(x => x.ProductInStock).NotEmpty().WithMessage("Please enter a product in stock!");

        }
        
    }
}
