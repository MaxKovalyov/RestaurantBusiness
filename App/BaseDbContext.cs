using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Configurations;

namespace RestaurantBusiness.App
{
    public class BaseDbContext: DbContext
    {
        public BaseDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EventProductsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEventConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTableConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
