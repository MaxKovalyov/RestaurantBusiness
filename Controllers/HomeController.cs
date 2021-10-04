using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.App.Services;
using RestaurantBusiness.App.ViewModels;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        private readonly IRestaurantService _restaurantService;

        private readonly int _pageSize = 3;
        public HomeController(INewsService newsService, IRestaurantService restaurantService)
        {
            _newsService = newsService;
            _restaurantService = restaurantService;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            IEnumerable<News> news = await _newsService.GetAll();
            var countItems = news.Count();
            var items = news.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _pageSize);
            var model = new HomeViewModel()
            {
                Restaurants = await _restaurantService.GetAll(),
                News = items,
                PageModel = pageModel
            };
            
            ViewBag.Title = "Главная страница";
            return View(model);
        }

        [Route("/Admin/Home/EditNews")]
        public async Task<IActionResult> EditNews(int page = 1)
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование новостей";
            IEnumerable<News> news = await _newsService.GetAll();
            var countItems = news.Count();
            var items = news.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _pageSize);
            var model = new NewsViewModel()
            {
                News = items,
                PageModel = pageModel
            };
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Home/EditNews")]
        public async Task<IActionResult> EditNews(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _newsService.GetByIdAsync(model.OneNews.Id) != null)
                {
                    await _newsService.Update(model.OneNews);
                }
                else
                {
                    await _newsService.AddAsync(model.OneNews);
                }
                return Redirect("~/Admin/Home/EditNews");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование новостей";
                IEnumerable<News> news = await _newsService.GetAll();
                var countItems = news.Count();
                var items = news.Skip((model.PageModel.PageNumber - 1) * _pageSize).Take(_pageSize).ToList();
                var pageModel = new PageViewModel(countItems, model.PageModel.PageNumber, _pageSize);
                model.News = items;
                model.PageModel = pageModel;
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Home/DeleteNews")]
        public async Task DeleteNews(Guid id)
        {
            await _newsService.DeleteAsync(id);
        }
    }
}
