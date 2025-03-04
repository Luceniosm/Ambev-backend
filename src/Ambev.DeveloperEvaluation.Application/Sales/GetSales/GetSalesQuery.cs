using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesQuery: IRequest<GetSalesResult>
{
    public Guid Id { get; set; }
}