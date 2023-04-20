using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    internal class CreateCategoryValidation:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidation()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage(a => "Name Is Empty")
                .NotNull().WithMessage(a => "Name Is Required")
                .MinimumLength(3).WithMessage(a => "Min Name Is 3 Char")
                .MaximumLength(200).WithMessage(a => "Name Must Not Exceed 200 Char");
        }
    }
}
