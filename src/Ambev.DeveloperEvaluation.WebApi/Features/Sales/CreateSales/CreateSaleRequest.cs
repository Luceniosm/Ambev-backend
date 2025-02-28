namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public record CreateSaleRequest(
    string Custumer,
    string Branch,
    decimal TotalSale,
    List<CreateSaleItemRequest> SaleItems
    );
