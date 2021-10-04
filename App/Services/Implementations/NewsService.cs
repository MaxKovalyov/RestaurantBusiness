using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<News> _repository;

        public NewsService(IRepository<News> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(News model)
        {
            model.Id = new Guid();
            model.Date = DateTime.Now;
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var news = await _repository.GetByIdAsync(id);

            if (news == null)
            {
                throw new Exception("Delete: Новость не найдена");
            }

            await _repository.DeleteAsync(news);
        }

        public async Task<List<News>> GetAll()
        {
            var result = await _repository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<News>();
        }

        public async Task Update(News model)
        {
            var news = await _repository.GetByIdAsync(model.Id);

            if (news == null)
            {
                throw new Exception("Update: Новость не найдена");
            }

            news.Content = model.Content;
            news.Date = DateTime.Now;
            news.Description = model.Description;
            
            await _repository.UpdateAsync(news);
        }

        public async Task<News> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
