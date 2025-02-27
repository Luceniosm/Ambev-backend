using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(p => p.UpdatedAt);
        
        //Seeds
        builder.HasData(
            new Product(Guid.Parse("E960583F-985F-4A2C-99B6-74F398203DB4"), "Original", 5.00m),
            new Product(Guid.Parse("0DED9624-32F6-43BD-A2CA-A53C3034FB96"), "Budweiser", 3.50m),
            new Product(Guid.Parse("12A1A395-DC65-4E6C-B7F8-13E606982650"), "Michelob", 4.50m),
            new Product(Guid.Parse("8A965AFD-91CD-464E-9313-1DF1CBD8AE1C"), "Heineken", 4.00m),
            new Product(Guid.Parse("87D2999D-6FE9-49BB-8A96-5AEEA262439A"), "Corona", 4.25m)
        );
    }
}