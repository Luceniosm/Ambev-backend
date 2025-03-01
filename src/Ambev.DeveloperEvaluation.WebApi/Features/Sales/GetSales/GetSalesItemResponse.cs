namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public record GetSalesItemResponse
(
    Guid Id,
    string ProductName,
    string ProductId,
    decimal Price,
    int Quantity,
    decimal TotalPrice
);
    
    
