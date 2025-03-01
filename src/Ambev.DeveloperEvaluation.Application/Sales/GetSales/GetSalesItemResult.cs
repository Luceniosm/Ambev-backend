namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesItemResult
(
    Guid Id,
    string ProductName,
    string ProductId,
    decimal Price,
    int Quantity,
    decimal TotalPrice
);