using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class CategoryValidators : AbstractValidator<CategoryDto>
    {
        public CategoryValidators() 
        {
            RuleFor(c => c.Name)
               .NotEmpty()
               .NotNull()
               .MinimumLength(2);
        }
    }
}
