using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandHandler: IRequestHandler<UpdateSaleCommand, UpdateSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    
    public UpdateSaleCommandHandler(
        ISaleRepository saleRepository,
        ISaleItemRepository saleItemRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _saleItemRepository = saleItemRepository;
    }
            
    public async Task<UpdateSaleResponse> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale == null)
        {
            throw new InvalidOperationException("Sale not found");
        }

        sale.AlterTotalSale(request.TotalSale);
        sale.AlterBranch(request.Branch);
        sale.AlterCustomer(request.Customer);

        await _saleRepository.UpdateSale(sale, cancellationToken);
        await UpdateSaleItems(sale, request.SaleItems, cancellationToken);

        return new UpdateSaleResponse(true);
    }

    private async Task UpdateSaleItems(Sale sale, List<UpdateSaleItemDto> requestSaleItems, CancellationToken cancellationToken)
    {
        var updatedSaleItemsList = new List<SaleItem>();
        foreach (var item in requestSaleItems)
        {
            var saleItem = sale.SaleItems.FirstOrDefault(el => el.Id == item.Id);
            saleItem?.UpdateQuantityPrice(item.Quantity, item.Price);
            if (saleItem != null) updatedSaleItemsList.Add(saleItem);
        }
        
        await _saleItemRepository.UpdateSalesItems(updatedSaleItemsList, cancellationToken);
    }
}