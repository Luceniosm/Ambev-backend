using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Sales;

public class SalesItemTest
{
    // teste creater sale item
    [Fact(DisplayName = "Should correctly create a SaleItem entity")]
    public void TestSaleItemCreation()
    {
        // Arrange
        var id = Guid.NewGuid();
        var saleId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var quantity = 10;
        var price = 2.50m;

        // Act
        var saleItem = new SaleItem(id, productId, saleId, quantity, price);

        // Assert
        saleItem.Id.Should().Be(id);
        saleItem.ProductId.Should().Be(productId);
        saleItem.SaleId.Should().Be(saleId);
        saleItem.Quantity.Should().Be(quantity);
        saleItem.Price.Should().Be(price);
    }
    
    [Fact]
    public void Should_Apply_10_Percent_Discount()
    {
        // Arrange
        var id = Guid.NewGuid();
        var saleId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var quantity = 8;
        var price = 2.50m;
        
        // Arrange
        var saleItem = new SaleItem(id, productId, saleId, quantity, price);

        // Act
        var totalPrice = saleItem.TotalPrice;

        // Assert
        totalPrice.Should().Be(18);
    }
    
    [Fact]
    public void Should_Apply_20_Percent_Discount()
    {
        // Arrange
        var id = Guid.NewGuid();
        var saleId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var quantity = 15;
        var price = 4m;
        
        // Arrange
        var saleItem = new SaleItem(id, productId, saleId, quantity, price);

        // Act
        var totalPrice = saleItem.TotalPrice;

        // Assert
        totalPrice.Should().Be(48);
    }
    
    [Fact]
    public void Should_Not_Apply_Discount()
    {
        // Arrange
        var id = Guid.NewGuid();
        var saleId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var quantity = 3;
        var price = 10m;
        
        // Arrange
        var saleItem = new SaleItem(id, productId, saleId, quantity, price);

        // Act
        var totalPrice = saleItem.TotalPrice;

        // Assert
        totalPrice.Should().Be(30);
    }

}