using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Logiwa.ProductManagement
{
    internal class CategoryValid : AbstractValidator<CategoryData>
    {
        public CategoryValid() {

            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name cannot be null!");
        
        }
    }
}
