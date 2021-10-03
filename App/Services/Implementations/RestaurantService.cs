using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RestaurantBusiness.App.Repository;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _repository;
        IWebHostEnvironment _appEnvironment;

        public RestaurantService(IRepository<Restaurant> repository, IWebHostEnvironment appEnvironment)
        {
            _repository = repository;
            _appEnvironment = appEnvironment;
        }

        public async Task AddAsync(Restaurant model, IFormFile file)
        {
            if(file != null)
            {
                model.Image = "/images/Restaurants/" + file.FileName;
                await UploadFile(file, model.Image);
            }
            model.Id = new Guid();
            await _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var restaurant = await _repository.GetByIdAsync(id);

            if (restaurant == null)
            {
                throw new Exception("Delete: Ресторан не найден");
            }

            DeleteFile(restaurant.Image);

            await _repository.DeleteAsync(restaurant);
        }

        public async Task<List<Restaurant>> GetAll()
        {
            var result = await _repository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<Restaurant>();
        }

        public async Task Update(Restaurant model, IFormFile file)
        {
            var restaurant = await _repository.GetByIdAsync(model.Id);

            if (restaurant == null)
            {
                throw new Exception("Update: Ресторан не найден");
            }

            if(file != null)
            {
                model.Image = "/images/Restaurants/" + file.FileName;
                if (restaurant.Image != model.Image)
                {
                    DeleteFile(restaurant.Image);
                    restaurant.Image = model.Image;
                    await UploadFile(file, model.Image);
                }
            }

            restaurant.Adress = model.Adress;
            restaurant.Title = model.Title;

            await _repository.UpdateAsync(restaurant);
        }

        public async Task<Restaurant> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UploadFile(IFormFile file, string path)
        {
            if(file != null)
            {
                if (File.Exists(_appEnvironment.WebRootPath + path))
                {
                    File.Delete(_appEnvironment.WebRootPath + path);
                }
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }

        public void DeleteFile(string path)
        {
            if(File.Exists(_appEnvironment.WebRootPath + path))
            {
                File.Delete(_appEnvironment.WebRootPath + path);
            }
        }

        public Task AddAsync(Restaurant model)
        {
            throw new NotImplementedException();
        }

        public Task Update(Restaurant model)
        {
            throw new NotImplementedException();
        }
    }
}
