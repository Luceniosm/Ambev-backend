using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    public CreateSaleItemRequestValidator()
    {
        RuleFor(item => item.ProductId).NotEmpty();
        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .WithMessage("The quantity must be greater than zero.")
            .LessThanOrEqualTo(20)
            .WithMessage("The quantity must not be greater than 20.");
        RuleFor(item => item.Price).GreaterThan(0);
    }
}