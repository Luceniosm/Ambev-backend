using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.Sales;

public class SaleTest
{
    [Fact(DisplayName = "Should correctly create a Sale entity")]
    public void TestSaleCreation()
    {
        // Arrange
        var id = Guid.NewGuid();
        var customer = "John Doe";
        var branch = "Amazon";
        var totalSale = 100.0m;

        // Act
        var sale = new Sale(id, customer, branch, totalSale);

        // Assert
        sale.Customer.Should().Be(customer);
        sale.Branch.Should().Be(branch);
        sale.TotalSale.Should().Be(totalSale);
        sale.SaleItems.Should().BeNull();
    }
}