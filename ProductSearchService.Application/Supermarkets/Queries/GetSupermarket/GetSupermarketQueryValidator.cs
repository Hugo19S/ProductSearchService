using FluentValidation;

namespace ProductSearchService.Application.Supermarkets.Queries.GetSupermarket;

public class GetSupermarketQueryValidator : AbstractValidator<GetSupermarketQuery>
{
    public GetSupermarketQueryValidator() 
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("The Id can't be empty.");
    }
}
