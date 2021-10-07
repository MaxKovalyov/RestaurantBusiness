using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IRestaurantService _restaurantService;

        private readonly int _restaurantPageSize = 4;
        private readonly int _reviewPageSize = 5;

        public AboutController(IReviewService reviewService, IRestaurantService restaurantService)
        {
            _reviewService = reviewService;
            _restaurantService = restaurantService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Restaurants(int page = 1)
        {
            IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
            var countItems = restaurants.Count();
            var items = restaurants.Skip((page - 1) * _restaurantPageSize).Take(_restaurantPageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _restaurantPageSize);
            var model = new AboutRestaurantViewModel()
            {
                Restaurants = items,
                PageModel = pageModel
            };
            ViewBag.Title = "Рестораны";
            return View(model);
        }

        [Route("/Admin/About/EditRestaurants")]
        public async Task<IActionResult> EditRestaurants(int page = 1)
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование ресторанов";
            IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
            var countItems = restaurants.Count();
            var items = restaurants.Skip((page - 1) * _restaurantPageSize).Take(_restaurantPageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _restaurantPageSize);
            var model = new RestaurantViewModel()
            {
                Restaurants = items,
                PageModel = pageModel
            };

            return View(model);
        }

        [HttpPost]
        [Route("/Admin/About/EditRestaurants")]
        public async Task<IActionResult> EditRestaurants(RestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _restaurantService.GetByIdAsync(model.Restaurant.Id) != null)
                {
                    await _restaurantService.Update(model.Restaurant, model.File);
                }
                else
                {
                    await _restaurantService.AddAsync(model.Restaurant, model.File);
                }
                return Redirect("~/Admin/About/EditRestaurants");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование ресторанов";
                IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
                var countItems = restaurants.Count();
                var items = restaurants.Take(_restaurantPageSize).ToList();
                var pageModel = new PageViewModel(countItems, 1, _restaurantPageSize);
                model.Restaurants = items;
                model.PageModel = pageModel;
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/About/DeleteRestaurant")]
        public async Task DeleteRestaurant(Guid id)
        {
            await _restaurantService.DeleteAsync(id);
        }

        [AllowAnonymous]
        public IActionResult Service()
        {
            ViewBag.Title = "Обслуживание";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            ViewBag.Title = "Контакты";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Awards()
        {
            ViewBag.Title = "Награды";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Staff()
        {
            ViewBag.Title = "Персонал";
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Reviews(int page = 1)
        {
            ViewBag.Title = "Отзывы";
            IEnumerable<Review> reviews = await _reviewService.GetAll();
            var countItems = reviews.Count();
            var items = reviews.Skip((page - 1) * _reviewPageSize).Take(_reviewPageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _reviewPageSize);
            var model = new ReviewViewModel()
            {
                Reviews = items,
                PageModel = pageModel,
                IsEven = true
            };
            return View(model);
        }

        [Route("/Admin/About/EditReviews")]
        public async Task<IActionResult> EditReviews(int page = 1)
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование отзывов";
            IEnumerable<Review> reviews = await _reviewService.GetAll();
            var countItems = reviews.Count();
            var items = reviews.Skip((page - 1) * _reviewPageSize).Take(_reviewPageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _reviewPageSize);
            var model = new ReviewViewModel()
            {
                Reviews = items,
                PageModel = pageModel
            };
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Reviews(ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _reviewService.AddAsync(model.Review);
                return Redirect("~/About/Reviews");
            }
            else
            {
                ViewBag.Title = "Редактирование отзывов";
                IEnumerable<Review> reviews = await _reviewService.GetAll();
                var countItems = reviews.Count();
                var items = reviews.Take(_reviewPageSize).ToList();
                var pageModel = new PageViewModel(countItems, 1, _reviewPageSize);
                model.Reviews = items;
                model.PageModel = pageModel;
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/About/DeleteReview")]
        public async Task DeleteReview(Guid id)
        {
            await _reviewService.DeleteAsync(id);
        }
    }
}
