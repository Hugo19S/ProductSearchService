using FluentValidation;

namespace ProductSearchService.Application.Supermarkets.Commands.CreateSupermarket;

public class CreateSupermarketCommandValidator : AbstractValidator<CreateSupermarketCommand>
{
    public CreateSupermarketCommandValidator()
    {
        RuleFor(x => x.SupermarketName)
            .NotEmpty().WithMessage("SupermarketName can't be empty.");
    }
}
