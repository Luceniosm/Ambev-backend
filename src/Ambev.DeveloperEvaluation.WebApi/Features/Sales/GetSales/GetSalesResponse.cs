namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public record GetSalesResponse
(
    Guid Id,
    string Branch,
    string Customer,
    decimal TotalSale,
    List<GetSalesItemResponse> SaleItems
);