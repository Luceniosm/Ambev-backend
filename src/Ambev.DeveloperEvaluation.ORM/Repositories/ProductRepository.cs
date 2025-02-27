using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateProduct(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default) =>
        await _context.Products.FirstOrDefaultAsync(el => el.Id == id, cancellationToken);
    
    public async Task<List<Product>> GetAllProductsActives(CancellationToken cancellationToken = default) =>
        await _context.Products.Where(el => el.Status == ProductStatus.Active).ToListAsync(cancellationToken);
}