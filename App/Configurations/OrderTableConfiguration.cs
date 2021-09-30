using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantBusiness.Models;

namespace RestaurantBusiness.App.Configurations
{
    public class OrderTableConfiguration : IEntityTypeConfiguration<OrderTable>
    {
        public void Configure(EntityTypeBuilder<OrderTable> builder)
        {
            builder.ToTable(nameof(OrderTable));

            builder.HasKey(ot => ot.Id);
            builder.Property(ot => ot.Id).ValueGeneratedOnAdd();

            builder.HasOne(ot => ot.Restaurant);
        }
    }
}
