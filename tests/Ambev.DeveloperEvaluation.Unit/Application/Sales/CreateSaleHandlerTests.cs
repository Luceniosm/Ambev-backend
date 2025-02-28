using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleCommandHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _saleItemRepository = Substitute.For<ISaleItemRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleCommandHandler(_saleRepository, _saleItemRepository, _mapper);
    }
    

    [Fact(DisplayName = "Should correctly map the result from the repository to CreateSaleResult")]
    public async Task Handle_ShouldMapRepositoryResultToCreateSaleResult()
    {
        // Arrange
        var createSaleCommand = new CreateSaleCommand
        {
            Customuer = "Paul",
            Branch = "Amazon",
            TotalSale = 100.0m,
            SaleItems = [
                new CreateSaleItemDto { ProductId = Guid.NewGuid(), Quantity = 2, Price = 3.5m }
            ]
        };

        var sale = new Sale(Guid.NewGuid(), createSaleCommand.Customuer, createSaleCommand.Branch, createSaleCommand.TotalSale);
        var saleResult = new CreateSaleResult { Id = sale.Id };

        _saleRepository.CreateSale(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(new CreateSaleResult { Id = saleResult.Id });

        // When
        var result = await _handler.Handle(createSaleCommand, CancellationToken.None);

        // Then
        result.Should().NotBeNull();
        result.Id.Should().Be(saleResult.Id);
    }
}