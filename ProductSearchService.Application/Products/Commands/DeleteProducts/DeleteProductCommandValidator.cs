using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.Products.Commands.DeleteProducts;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.ProductId)
            .NotNull().WithMessage("The ProductId can't be Null.")
            .NotEmpty().WithMessage("The ProductId can't be empty.");
    }
}
