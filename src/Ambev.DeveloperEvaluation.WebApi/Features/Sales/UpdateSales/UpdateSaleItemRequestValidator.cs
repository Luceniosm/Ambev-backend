using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
{
    public UpdateSaleItemRequestValidator()
    {
        RuleFor(item => item.Id).NotEmpty();
        RuleFor(item => item.ProductId).NotEmpty();
        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .WithMessage("The quantity must be greater than zero.")
            .LessThanOrEqualTo(20)
            .WithMessage("The quantity must not be greater than 20.");
        RuleFor(item => item.Price).GreaterThan(0);
    }
}