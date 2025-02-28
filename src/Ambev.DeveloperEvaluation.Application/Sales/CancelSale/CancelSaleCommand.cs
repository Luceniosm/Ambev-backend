using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleCommand: IRequest<CancelSaleResponse>
{
    public Guid Id { get; set;  }
}