using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleItemRepository
{
    Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateSalesItems(List<SaleItem> saleItems, CancellationToken cancellationToken = default);
    Task UpdateSalesItems(List<SaleItem> saleItems, CancellationToken cancellationToken = default);
    Task<bool> CancelSaleItem(Guid id, CancellationToken cancellationToken = default);
}