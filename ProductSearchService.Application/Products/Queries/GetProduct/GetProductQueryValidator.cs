using ErrorOr;
using FluentValidation;
using MediatR;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.Products.Queries.GetProduct;

public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator()
    {
        RuleFor(p => p.Id)
            //.NotNull().WithMessage("The Id of product can't be Null.")
            .NotEmpty().WithMessage("The Id of product can't be empty.");
        //.Must(x => Guid.TryParse(x.ToString(), out _)).WithMessage("The Id must be a valid GUID.");
    }
}

