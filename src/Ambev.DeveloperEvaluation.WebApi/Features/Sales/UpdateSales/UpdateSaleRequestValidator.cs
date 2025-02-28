using AutoMapper;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
        RuleFor(request => request.Customer).NotEmpty();
        RuleFor(request => request.Branch).NotEmpty();
        RuleFor(request => request.TotalSale).GreaterThan(0);
        RuleFor(request => request.SaleItems).NotEmpty();
        RuleForEach(request => request.SaleItems)
            .NotEmpty()
            .SetValidator(new UpdateSaleItemRequestValidator());
    }
}