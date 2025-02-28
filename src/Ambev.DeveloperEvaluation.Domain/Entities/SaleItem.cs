using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem: BaseEntity
{
    public Guid ProductId { get; private set; }
    public Guid SaleId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }
    public decimal TotalPrice { get; private set; }
    public bool IsCanceled { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Product Product { get; set; }
    public Sale Sale { get; set; }
    
    protected SaleItem()
    { }

    public SaleItem(Guid id, Guid productId, Guid saleId, int quantity, decimal price)
    {
        Id = id;
        ProductId = productId;
        SaleId = saleId;
        Quantity = quantity;
        Price = price;
        TotalPrice = CalculateDiscountedPrice(price, quantity);
    }
    
    private decimal CalculateDiscountedPrice(decimal price, int quantity)
    {
        Discount = quantity switch
        {
            >= 10 and <= 20 => (price * quantity)* 0.2m,
            >= 4 => (price * quantity) * 0.1m,
            _ => 0
        };

        return (price * quantity) - Discount;
    }

    public void UpdateQuantityPrice(int newQuantity, decimal price)
    {
        Quantity = newQuantity;
        TotalPrice = CalculateDiscountedPrice(price, newQuantity);
        UpdatedAt = DateTime.UtcNow;
    }

    public void CancelItem()
    {
        IsCanceled = true;
        UpdatedAt = DateTime.Now;
    }


}