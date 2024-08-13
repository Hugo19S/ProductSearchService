using FluentValidation;
using System.Data;

namespace ProductSearchService.Application.SupermarketProducts.Queries.GetSupermarketProduct;

public class GetSupermarketProductQueryValidator : AbstractValidator<GetSupermarketProductQuery>
{
    public GetSupermarketProductQueryValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("The ProductId can't be empty.");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("The ProductId can't be empty.");
    }
}
