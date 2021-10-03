using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class ProductService: IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IFileService _fileService;

        public ProductService(IRepository<Product> repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task AddAsync(Product model, IFormFile file)
        {
            if (file != null)
            {
                model.Image = "/images/Products/" + file.FileName;
                await _fileService.UploadFile(file, model.Image);
            }
            model.Id = new Guid();
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                throw new Exception("Delete: Блюдо не найдено");
            }

            _fileService.DeleteFile(product.Image);

            await _repository.DeleteAsync(product);
        }

        public async Task<List<Product>> GetAll()
        {
            var result = await _repository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<Product>();
        }

        public async Task Update(Product model, IFormFile file)
        {
            var product = await _repository.GetByIdAsync(model.Id);

            if (product == null)
            {
                throw new Exception("Update: Блюдо не найдено");
            }

            if (file != null)
            {
                model.Image = "/images/Products/" + file.FileName;
                if (product.Image != model.Image)
                {
                    _fileService.DeleteFile(product.Image);
                    product.Image = model.Image;
                    await _fileService.UploadFile(file, model.Image);
                }
            }

            product.Cost = model.Cost;
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;

            await _repository.UpdateAsync(product);
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task AddAsync(Product model)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
