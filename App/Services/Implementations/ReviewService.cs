using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;

        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Review model)
        {
            model.Id = new Guid();
            model.Date = DateTime.Now;
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var review = await _repository.GetByIdAsync(id);

            if (review == null)
            {
                throw new Exception("Delete: Категория не найдена");
            }

            await _repository.DeleteAsync(review);
        }

        public async Task<List<Review>> GetAll()
        {
            var result = await _repository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<Review>();
        }

        public Task<Review> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Review model)
        {
            throw new NotImplementedException();
        }
    }
}
