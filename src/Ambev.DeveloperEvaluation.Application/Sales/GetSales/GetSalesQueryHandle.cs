using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesQueryHandle : IRequestHandler<GetSalesQuery, GetSalesResult>
{
    private readonly ISaleRepository _salesRepository;
    private readonly IMapper _mapper;

    public GetSalesQueryHandle(ISaleRepository salesRepository, IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }

    public async Task<GetSalesResult> Handle(GetSalesQuery request, CancellationToken cancellationToken)
    {
        var result = await _salesRepository.GetByIdWithSalesItemAndProductAsync(request.Id, cancellationToken);
        return _mapper.Map<GetSalesResult>(result);
    }
}