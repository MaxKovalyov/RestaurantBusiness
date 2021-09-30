using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantBusiness.Models;

namespace RestaurantBusiness.App.Configurations
{
    public class OrderEventConfiguration : IEntityTypeConfiguration<OrderEvent>
    {
        public void Configure(EntityTypeBuilder<OrderEvent> builder)
        {
            builder.ToTable(nameof(OrderEvent));

            builder.HasKey(oe => oe.Id);
            builder.Property(oe => oe.Id).ValueGeneratedOnAdd();

            builder.HasOne(oe => oe.Restaurant);

            builder.HasMany(oe => oe.EventProducts)
                .WithOne(ep => ep.OrderEvent)
                .HasForeignKey(ep => ep.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderEvent_OrderProducts");
        }
    }
}
