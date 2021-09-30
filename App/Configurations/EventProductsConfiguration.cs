using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantBusiness.Models;

namespace RestaurantBusiness.App.Configurations
{
    public class EventProductsConfiguration : IEntityTypeConfiguration<EventProducts>
    {
        public void Configure(EntityTypeBuilder<EventProducts> builder)
        {
            builder.ToTable(nameof(EventProducts));

            builder.HasOne(ep => ep.OrderEvent);

            builder.HasOne(ep => ep.Product);

            builder.HasKey(ep => ep.EventId);
            builder.HasKey(ep => ep.ProductId);

        }
    }
}
