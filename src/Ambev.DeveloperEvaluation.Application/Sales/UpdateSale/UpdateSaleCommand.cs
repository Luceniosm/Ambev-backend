using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommand: IRequest<UpdateSaleResponse>
{
    public Guid Id { get; set; }
    public string Customer { get; set; }
    public string Branch { get; set; }
    public decimal TotalSale { get; set; }
    public List<UpdateSaleItemDto> SaleItems { get; set; }
}