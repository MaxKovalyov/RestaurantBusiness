using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class OrderTableService:IOrderTableService
    {
        private readonly IRepository<OrderTable> _repository;

        public OrderTableService(IRepository<OrderTable> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(OrderTable model)
        {
            model.Id = new Guid();
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderTable = await _repository.GetByIdAsync(id);

            if (orderTable == null)
            {
                throw new Exception("Delete: Заказ столика не найден");
            }

            await _repository.DeleteAsync(orderTable);
        }

        public async Task<List<OrderTable>> GetAll()
        {
            var result = await _repository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<OrderTable>();
        }

        public async Task Update(OrderTable model)
        {
            var orderTable = await _repository.GetByIdAsync(model.Id);

            if (orderTable == null)
            {
                throw new Exception("Update: Заказ столика не найден");
            }


            await _repository.UpdateAsync(orderTable);
        }

        public async Task<OrderTable> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
