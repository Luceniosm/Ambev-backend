using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale: BaseEntity
{
    public string ClienteName { get; private set; }
    public int SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public string Customer { get; private set; }
    public decimal TotalSale { get; private set; }
    public string Branch { get; private set; }
    public bool IsCanceled { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public ICollection<SaleItem> SaleItens { get; set; }
    
    protected Sale()
    { }

    public Sale(string clienteName, int saleNumber, DateTime saleDate, string customer, decimal totalSale, string branch)
    {
        ClienteName = clienteName;
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        Customer = customer;
        TotalSale = totalSale;
        Branch = branch;
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