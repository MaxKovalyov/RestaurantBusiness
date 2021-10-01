using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Category model)
        {
            model.Id = new Guid();
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);

            if(category == null)
            {
                throw new Exception("Delete: Категория не найдена");
            }

            await _repository.DeleteAsync(category);
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var result = await _repository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<Category>();
        }

        public async Task Update(Category model)
        {
            var category = await _repository.GetByIdAsync(model.Id);

            if(category == null)
            {
                throw new Exception("Update: Категория не найдена");
            }

            category.CategoryName = model.CategoryName;

            await _repository.UpdateAsync(category);
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
