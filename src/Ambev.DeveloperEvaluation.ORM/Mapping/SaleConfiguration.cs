using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration: IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).IsRequired();
        builder.Property(s => s.ClienteName).HasMaxLength(100).IsRequired();
        builder.Property(s => s.SaleNumber).IsRequired();
        builder.Property(s => s.SaleDate).IsRequired();
        builder.Property(s => s.Customer).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Branch).HasMaxLength(100).IsRequired();
        
        builder.Property(s => s.TotalSale).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(s => s.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(s => s.UpdatedAt);
    }
}