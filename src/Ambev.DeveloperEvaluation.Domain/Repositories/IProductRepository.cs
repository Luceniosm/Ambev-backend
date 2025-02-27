using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product>CreateProduct(Product product, CancellationToken cancellationToken = default);
    Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAllProductsActives(CancellationToken cancellationToken = default);
}