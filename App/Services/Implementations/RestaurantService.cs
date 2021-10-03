using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _repository;

        public RestaurantService(IRepository<Restaurant> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Restaurant model)
        {
            model.Id = new Guid();
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var restaurant = await _repository.GetByIdAsync(id);

            if (restaurant == null)
            {
                throw new Exception("Delete: Категория не найдена");
            }

            await _repository.DeleteAsync(restaurant);
        }

        public async Task<List<Restaurant>> GetAll()
        {
            var result = await _repository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<Restaurant>();
        }

        public async Task Update(Restaurant model)
        {
            var news = await _repository.GetByIdAsync(model.Id);

            if (news == null)
            {
                throw new Exception("Update: Категория не найдена");
            }

            

            await _repository.UpdateAsync(news);
        }

        public async Task<News> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
