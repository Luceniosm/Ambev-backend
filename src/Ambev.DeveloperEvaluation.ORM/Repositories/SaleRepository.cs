using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository: ISaleRepository
{
    private readonly DefaultContext _context;
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context
            .Sales
            .Include(el => el.SaleItems)
            .FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<Sale?> GetByIdWithSalesItemAndProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context
            .Sales
            .Include(el => el.SaleItems)
                .ThenInclude(el => el.Product)
            .FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<Sale> CreateSale(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task UpdateSale(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
    }
}