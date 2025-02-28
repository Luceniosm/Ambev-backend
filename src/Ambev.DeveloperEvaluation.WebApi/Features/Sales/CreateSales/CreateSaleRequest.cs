namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public record CreateSaleRequest(
    string Customuer,
    string Branch,
    decimal TotalSale,
    List<CreateSaleItemRequest> SaleItems
    );
