using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

public class CancelSaleItemCommandHandler: IRequestHandler<CancelSaleItemCommand, CancelSaleItemResponse>
{
    private readonly ISaleItemRepository _saleItemRepository;
    
    public CancelSaleItemCommandHandler(ISaleItemRepository saleItemRepository)
    {
        _saleItemRepository = saleItemRepository;
    }
    
    public async Task<CancelSaleItemResponse> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken) =>
         new (await _saleItemRepository.CancelSaleItem(request.Id, cancellationToken));
}