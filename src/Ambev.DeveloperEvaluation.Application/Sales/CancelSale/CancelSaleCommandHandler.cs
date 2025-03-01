using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleCommandHandler : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    
    public CancelSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }
    public async Task<CancelSaleResponse> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale == null)
            throw new InvalidOperationException("Sale item not found");
        
        
        sale.CancelSale();
        await _saleRepository.UpdateSale(sale, cancellationToken);
        return new CancelSaleResponse(true);
    }
}