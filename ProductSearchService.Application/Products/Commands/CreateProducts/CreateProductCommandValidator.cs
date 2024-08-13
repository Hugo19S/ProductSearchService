using FluentValidation;

namespace ProductSearchService.Application.Products.Commands.CreateProducts;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("The Name of product can't be empty.")
            .MaximumLength(150).WithMessage("The Name must have maximum 150 chars.");

        RuleFor(p => p.Barcode)
            .NotEmpty().WithMessage("The Barcode of product can't be empty.")
            .MaximumLength(25).WithMessage("The Barcode must have maximum 25 chars.");
    }
}
