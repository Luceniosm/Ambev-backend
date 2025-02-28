namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public DateTime DateSale { get; set; }
    public string Custumer { get; set; }
    public decimal TotalSale { get; set; }
    public decimal Discount { get; set; }
    public bool IsCancelled { get; set; }
}