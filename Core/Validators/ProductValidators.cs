using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class ProductValidators : AbstractValidator<ProductDto>
    {
        public ProductValidators() 
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2);
            RuleFor(m => m.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5);
        }
    }
}
