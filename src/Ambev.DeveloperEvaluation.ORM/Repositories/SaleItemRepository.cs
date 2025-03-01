using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _context.SaleItems.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    

    public async Task CreateSalesItems(List<SaleItem> saleItems, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddRangeAsync(saleItems, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateSalesItems(List<SaleItem> saleItems, CancellationToken cancellationToken = default)
    {
        _context.SaleItems.UpdateRange(saleItems);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> CancelSaleItem(Guid id, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(el => 
                el.SetProperty(s => s.IsCanceled, true),cancellationToken);
        
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

   
}