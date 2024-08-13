using FluentValidation;

namespace ProductSearchService.Application.SupermarketProducts.Commands.CreateSupermarketProduct;

public class CreateSupermarketProductCommandValidator : AbstractValidator<CreateSupermarketProductCommand>
{
    public CreateSupermarketProductCommandValidator()
    {
        RuleFor(p => p.SupermarketId)
            .NotEmpty().WithMessage("SupermarketId can't be empty.");

        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("ProductId can't be empty.");
        
        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("Quantity can't be empty.");
        
        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price can't be empty.");
    }
}
