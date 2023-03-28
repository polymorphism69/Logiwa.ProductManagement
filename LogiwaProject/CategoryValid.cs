using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LogiwaProject
{
    internal class CategoryValid:AbstractValidator<Category>
    {

        public CategoryValid() {

            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Please enter a id for category!");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Please enter a name for category!");
        }

    }
}
