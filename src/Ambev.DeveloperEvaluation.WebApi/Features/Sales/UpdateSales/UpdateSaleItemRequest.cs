namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public record UpdateSaleItemRequest(
    Guid? Id,
    Guid ProductId,
    int Quantity,
    decimal Price);
    
