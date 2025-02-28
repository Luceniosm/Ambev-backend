namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public record CreateSaleItemDto
(
    Guid ProductId,
    int Quantity,
    decimal Price
);