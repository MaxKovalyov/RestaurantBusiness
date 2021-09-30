using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantBusiness.Models;

namespace RestaurantBusiness.App.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable(nameof(Restaurant));

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.HasMany(r => r.TableOrders)
                .WithOne(to => to.Restaurant)
                .HasForeignKey(to => to.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Restaurant_TableOrders");

            builder.HasMany(r => r.EventOrders)
                .WithOne(eo => eo.Restaurant)
                .HasForeignKey(eo => eo.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Restaurant_EventOrders");
        }
    }
}
