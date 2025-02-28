using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale: BaseEntity
{
    public long SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public string Customer { get; private set; }
    public decimal TotalSale { get; private set; }
    public string Branch { get; private set; }
    public bool IsCanceled { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public ICollection<SaleItem> SaleItems { get; set; }
    
    protected Sale()
    { }

    public Sale(Guid id, string customer, string branch, decimal totalSale)
    {
        Id = id;
        Customer = customer;
        Branch = branch;
        TotalSale = totalSale;
        SaleDate = DateTime.UtcNow;;
    }

    public void AlterTotalSale(decimal totalSale)
    {
        TotalSale = totalSale;
        UpdatedAt = DateTime.Now;
    }

    public void CancelSale()
    {
        IsCanceled = true;
        UpdatedAt = DateTime.Now;
    }
}