using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface IOrderEventService
    {
        Task AddAsync(OrderEvent model, List<Guid> OrderedProducts);

        Task<List<OrderEvent>> GetAll();

        Task Update(OrderEvent model, List<Guid> OrderedProducts);

        Task DeleteAsync(Guid id);

        Task<OrderEvent> GetByIdAsync(Guid id);
    }
}
