using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController: BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<List<GetProdutctsResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        var response = await _mediator.Send(new GetProductsQuery());
        return Ok(new ApiResponseWithData<List<GetProdutctsResponse>>
        {
            Success = true,
            Message = "Products retrieved successfully",
            Data = _mapper.Map<List<GetProdutctsResponse>>(response)
        });
    }
}