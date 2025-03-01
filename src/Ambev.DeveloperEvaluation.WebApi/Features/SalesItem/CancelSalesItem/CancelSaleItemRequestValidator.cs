using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CancelSalesItem;

public class CancelSaleItemRequestValidator :  AbstractValidator<CancelSaleItemRequest>
{
    public CancelSaleItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale Item ID is required");
    }
    
}