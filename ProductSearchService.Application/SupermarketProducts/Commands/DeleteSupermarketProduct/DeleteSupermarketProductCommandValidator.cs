using FluentValidation;

namespace ProductSearchService.Application.SupermarketProducts.Commands.DeleteSupermarketProduct;

public class DeleteSupermarketProductCommandValidator : AbstractValidator<DeleteSupermarketProductCommand>
{
    public DeleteSupermarketProductCommandValidator()
    {
        RuleFor(x => x.SupermarketId)
            .NotEmpty().WithMessage("The SupermarketId can't be empty.");
        
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("The ProductId can't be empty.");
    }
}
