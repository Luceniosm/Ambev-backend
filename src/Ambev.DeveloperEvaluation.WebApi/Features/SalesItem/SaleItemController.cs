using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItem.CancelSalesItem;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItem;

[ApiController]
[Route("api/[controller]")]
public class SaleItemController  : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SaleItemController(
        IMediator mediator, 
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPatch]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddSaleItem([FromBody] CancelSaleItemRequest request,
        CancellationToken cancellationToken)
    {
        var validator = new CancelSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CancelSaleItemCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        
        if (!response.Success)
            return StatusCode(404, new ApiResponse
            {
                Success = false, 
                Message = "Failed to cancel sale item"
            });

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale item cancelled successfully"
        });
    }
}