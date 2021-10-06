using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class EventProductsService : IEventProductsService
    {
        private readonly IRepository<EventProducts> _repository;

        public EventProductsService(IRepository<EventProducts> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(EventProducts model)
        {
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(EventProducts model)
        {
            await _repository.DeleteAsync(model);
        }
    }
}
