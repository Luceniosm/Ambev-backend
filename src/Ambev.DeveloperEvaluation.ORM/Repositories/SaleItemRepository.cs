using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task CreateSalesItems(List<SaleItem> saleItems, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddRangeAsync(saleItems, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}