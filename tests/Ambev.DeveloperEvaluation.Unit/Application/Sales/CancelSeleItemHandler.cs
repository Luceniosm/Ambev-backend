using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class CancelSeleItemHandler
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly CancelSaleItemCommandHandler _handler;

    public CancelSeleItemHandler()
    {
        _saleItemRepository = Substitute.For<ISaleItemRepository>();
        _handler = new CancelSaleItemCommandHandler(_saleItemRepository);
    }

    [Fact(DisplayName = "Should cancel sale item successfully")]
    public async Task ShouldCancelSaleItem()
    {
        // Arrange
        var command = new CancelSaleItemCommand { Id = Guid.NewGuid() };
        _saleItemRepository.CancelSaleItem(command.Id).Returns(Task.FromResult(true));
        
        var response = await _handler.Handle(command, CancellationToken.None);
        response.Should().BeEquivalentTo(new CancelSaleItemResponse(true));
    }
}