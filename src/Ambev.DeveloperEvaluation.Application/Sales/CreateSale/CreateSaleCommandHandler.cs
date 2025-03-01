using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandHandler: IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    public CreateSaleCommandHandler(
        ISaleRepository saleRepository,
        ISaleItemRepository saleItemRepository,
        IMapper mapper
        )
    {
        _saleRepository = saleRepository;
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = new Sale(Guid.NewGuid(), request.Custumer, request.Branch, request.TotalSale);
        var result = await _saleRepository.CreateSale(sale, cancellationToken);

        await CreateSalesItem(sale.Id, request.SaleItems);
        return _mapper.Map<CreateSaleResult>(result);
    }

    private async Task CreateSalesItem(Guid saleId, List<CreateSaleItemDto> requestSaleItems)
    {
        var salesItem = requestSaleItems
            .Select(el => new SaleItem(Guid.NewGuid(), el.ProductId, saleId, el.Quantity, el.Price)).ToList();
        await _saleItemRepository.CreateSalesItems(salesItem, CancellationToken.None);
    }
}