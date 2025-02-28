using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class CancelSaleHandler
{
    private readonly ISaleRepository _saleRepository;
    private readonly CancelSaleCommandHandler _handler;

    public CancelSaleHandler()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _handler = new CancelSaleCommandHandler(_saleRepository);
    }

    [Fact(DisplayName = "Must cancel sales with sucessfully")]
    public async Task Handle_ShouldCancelSaleSucess()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        _saleRepository.GetByIdAsync(saleId).Returns(new Sale(saleId, "Paul", "Amazom", 100m));

        // Act
        var response = await _handler.Handle(new CancelSaleCommand { Id = saleId }, default);

        // Assert
        response.Success.Should().Be(true);
    }
    
    
    [Fact(DisplayName = "Must cancel sales that does not exist with failure")]
    public async Task Handle_ShouldCancelSaleFalse()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        _saleRepository.GetByIdAsync(saleId).Returns(new Sale(saleId, "Paul", "Amazom", 100m));

        // Act
        var response = await _handler.Handle(new CancelSaleCommand { Id = Guid.NewGuid() }, default);

        // Assert
        response.Success.Should().Be(false);
    }

}