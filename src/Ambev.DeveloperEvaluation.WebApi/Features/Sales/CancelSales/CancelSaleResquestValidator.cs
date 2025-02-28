using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSales;

public class CancelSaleResquestValidator :  AbstractValidator<CancelSaleRequest>
{
    public CancelSaleResquestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}