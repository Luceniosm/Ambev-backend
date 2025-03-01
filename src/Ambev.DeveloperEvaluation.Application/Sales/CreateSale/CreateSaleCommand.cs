using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string Custumer { get; set; }
    public string Branch { get; set; }
    public decimal TotalSale { get; set; }
    public List<CreateSaleItemDto> SaleItems { get; set; }
}