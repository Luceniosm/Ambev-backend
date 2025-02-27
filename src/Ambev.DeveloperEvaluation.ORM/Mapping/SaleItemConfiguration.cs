using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration: IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(si => si.Id);
        builder.Property(si => si.Id).IsRequired();
        builder.Property(si => si.ProductId).IsRequired();
        builder.Property(si => si.SaleId).IsRequired();
        builder.Property(si => si.Quantity).IsRequired();
        builder.Property(si => si.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(si => si.IsCanceled).IsRequired().HasDefaultValue(false);
        builder.Property(si => si.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(si => si.UpdatedAt);

        builder.HasOne(si => si.Sale)
           .WithMany(s => s.SaleItens)
           .HasForeignKey(si => si.SaleId)
           .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(si => si.Product)
            .WithMany()
            .HasForeignKey(si => si.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
    }
}