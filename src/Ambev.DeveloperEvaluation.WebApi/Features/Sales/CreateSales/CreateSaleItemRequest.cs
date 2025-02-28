namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public record CreateSaleItemRequest(
    Guid ProductId,
    int Quantity,
    decimal Price
);