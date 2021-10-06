using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class OrderEventService: IOrderEventService
    {
        private readonly IRepository<OrderEvent> _repository;
        private readonly IEventProductsService _eventProductsService;

        public OrderEventService(IRepository<OrderEvent> repository, IEventProductsService eventProductsService)
        {
            _repository = repository;
            _eventProductsService = eventProductsService;
        }

        public async Task AddAsync(OrderEvent model, List<Guid> OrderedProducts)
        {
            model.Id = new Guid();
            foreach(var item in OrderedProducts)
            {
                var eventProduct = new EventProducts()
                {
                    EventId = model.Id,
                    ProductId = item
                };
                await _eventProductsService.AddAsync(eventProduct);
                model.EventProducts.Add(eventProduct);
            }
            await _repository.AddAsync(model);
            
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderEvent = await _repository.GetByIdAsync(id);

            if (orderEvent == null)
            {
                throw new Exception("Delete: Заказ мероприятия не найден");
            }

            await _repository.DeleteAsync(orderEvent);
        }

        public async Task<List<OrderEvent>> GetAll()
        {
            var result = await _repository
                .GetAll()
                .Include(oe => oe.EventProducts)
                .ToListAsync();

            return result.Count > 0 ? result : new List<OrderEvent>();
        }

        public async Task Update(OrderEvent model, List<Guid> OrderedProducts)
        {
            var orderEvent = await _repository.GetByIdAsync(model.Id);

            if (orderEvent == null)
            {
                throw new Exception("Update: Заказ мероприятия не найден");
            }

            foreach(var item in orderEvent.EventProducts)
            {
                await _eventProductsService.DeleteAsync(item);
            }

            foreach(var item in OrderedProducts)
            {
                var eventProduct = new EventProducts()
                {
                    EventId = model.Id,
                    ProductId = item
                };
                await _eventProductsService.AddAsync(eventProduct);
                model.EventProducts.Add(eventProduct);
            }

            orderEvent.ClientName = model.ClientName;
            orderEvent.ClientPhone = model.ClientPhone;
            orderEvent.CountGuest = model.CountGuest;
            orderEvent.Date = model.Date;
            orderEvent.Description = model.Description;
            orderEvent.RestaurantId = model.RestaurantId;
            orderEvent.CostEvent = model.CostEvent;
            orderEvent.EventProducts = model.EventProducts;

            await _repository.UpdateAsync(orderEvent);
        }

        public async Task<OrderEvent> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
