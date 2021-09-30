using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantBusiness.Models;

namespace RestaurantBusiness.App.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable(nameof(News));

            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
        }
    }
}
