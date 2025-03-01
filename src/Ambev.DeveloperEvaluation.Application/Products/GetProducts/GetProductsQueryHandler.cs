using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;


public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<GetProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllProductsActives(cancellationToken);
        return result.Select(el => _mapper.Map<GetProductsResult>(el)).ToList();
    }
}