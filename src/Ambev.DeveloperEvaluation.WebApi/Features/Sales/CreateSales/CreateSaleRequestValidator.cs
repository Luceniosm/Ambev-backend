using FluentValidation;
using FluentValidation.Validators;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public class CreateSaleRequestValidator: AbstractValidator<CreateSaleRequest>
{ 
    public CreateSaleRequestValidator()
    {
        RuleFor(request => request.Custumer).NotEmpty();
        RuleFor(request => request.Branch).NotEmpty();
        RuleFor(request => request.TotalSale).GreaterThan(0);
        RuleFor(request => request.SaleItems).NotEmpty();
        RuleForEach(request => request.SaleItems)
            .NotEmpty()
            .SetValidator(new CreateSaleItemRequestValidator());
    }
}