using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Sale?> GetByIdWithSalesItemAndProductAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Sale>CreateSale(Sale sale, CancellationToken cancellationToken = default);
    Task UpdateSale(Sale sale, CancellationToken cancellationToken = default);
}