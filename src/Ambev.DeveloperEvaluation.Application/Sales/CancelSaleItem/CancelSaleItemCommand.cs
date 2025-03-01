using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

public class CancelSaleItemCommand: IRequest<CancelSaleItemResponse>
{
    public Guid Id { get; set; }
}