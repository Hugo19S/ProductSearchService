using FluentValidation;

namespace ProductSearchService.Application.SupermarketProducts.Commands.UpdateSupermarketProduct;

public class UpdateSupermarketProductCommandValidator : AbstractValidator<UpdateSupermarketProductCommand>
{
    public UpdateSupermarketProductCommandValidator() 
    {
        RuleFor(x => x.SupermarketId)
            .NotEmpty().WithMessage("The SupermarketId can't be empty.");
        
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("The ProductId can't be empty.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("The description must be no longer than 500 characters");
    }
}
