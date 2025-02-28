using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleItemRepository
{
    Task CreateSalesItems(List<SaleItem> saleItems, CancellationToken cancellationToken = default);
}