namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSales;

public record UpdateSaleRequest
(
        Guid Id,
        string Customer,
        string Branch,
        decimal TotalSale,
        List<UpdateSaleItemRequest> SaleItems
);
    
