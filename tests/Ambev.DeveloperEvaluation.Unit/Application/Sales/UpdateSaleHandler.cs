using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class UpdateSaleHandler
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;
    private readonly UpdateSaleCommandHandler _handler;

    public UpdateSaleHandler()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _saleItemRepository = Substitute.For<ISaleItemRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new UpdateSaleCommandHandler(_saleRepository, _saleItemRepository, _mapper);
    }

    [Fact(DisplayName = "Should correctly map the result from the repository to updateSaleResult")]
    public async Task Handle_ShouldMapRepositoryResultToUpdateSaleResult()
    {
        // Arrange
        var updateSaleCommand = new UpdateSaleCommand
        {
            Id = Guid.NewGuid(),
            Customer = "Paul",
            Branch = "Amazon",
            TotalSale = 100.0m,
            SaleItems =
            [
                new UpdateSaleItemDto(Guid.NewGuid(), 2, 3.5m)
            ]
        };

        var sale = new Sale(updateSaleCommand.Id, updateSaleCommand.Customer, updateSaleCommand.Branch, updateSaleCommand.TotalSale);
        sale.SaleItems = new List<SaleItem>
        {
            new (
                updateSaleCommand.SaleItems[0].Id,
                Guid.NewGuid(),
                sale.Id,
                updateSaleCommand.SaleItems[0].Quantity,
                updateSaleCommand.SaleItems[0].Price
                )
        };

        _saleRepository.GetByIdAsync(updateSaleCommand.Id, Arg.Any<CancellationToken>()).Returns(sale);
        _saleRepository.UpdateSale(sale, Arg.Any<CancellationToken>()).Returns(Task.CompletedTask);
        _saleItemRepository.UpdateSalesItems(Arg.Any<List<SaleItem>>(), Arg.Any<CancellationToken>()).Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(updateSaleCommand, CancellationToken.None);

        // Assert
        Assert.True(result.Success);
    }
}