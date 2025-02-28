namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public record UpdateSaleItemDto
(
    Guid Id,
    int Quantity,
    decimal Price
);