namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesResult
(
    Guid Id,
    string Branch,
    string Customer,
    decimal TotalSale,
    List<GetSalesItemResult> SaleItems
);
    
