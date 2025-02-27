using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem: BaseEntity
{
    public Guid ProductId { get; private set; }
    public Guid SaleId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public bool IsCanceled { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Product Product { get; set; }
    public Sale Sale { get; set; }
    
    protected SaleItem()
    { }

    public SaleItem(Guid productId, Guid saleId, int quantity, decimal price)
    {
        ProductId = productId;
        SaleId = saleId;
        Quantity = quantity;
        Price = price;
    }

    public void UpdateQuantity(int newQuantity)
    {
        Quantity = newQuantity;
        UpdatedAt = DateTime.Now;
    }

    public void CancelItem()
    {
        IsCanceled = true;
        UpdatedAt = DateTime.Now;
    }


}