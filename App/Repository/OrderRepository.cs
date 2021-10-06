using RestaurantBusiness.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantBusiness.App.Repository
{
    public class OrderRepository: Repository<OrderEvent>, IOrderRepository
    {
        public OrderRepository(BaseDbContext context):base(context)
        {
        }

        public async new Task<OrderEvent> GetByIdAsync(Guid id)
        {
            return await DbSet
                .Include(oe => oe.EventProducts)
                .Where(oe => oe.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
