using FluentValidation;

namespace ProductSearchService.Application.Products.Commands.UpdateProducts;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("The ProductId can't be empty.");

        RuleFor(p => p.ProductName)
            .MaximumLength(150).WithMessage("The Name must have maximum 150 chars.");

        RuleFor(p => p.Barcode)
            .MaximumLength(25).WithMessage("The Barcode must have maximum 25 chars.");
    }
}