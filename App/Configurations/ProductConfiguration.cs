using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantBusiness.Models;

namespace RestaurantBusiness.App.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Category);

            builder.HasMany(p => p.EventProducts)
                .WithOne(ep => ep.Product)
                .HasForeignKey(ep => ep.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_EventProducts");
        }
    }
}
