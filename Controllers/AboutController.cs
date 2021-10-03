using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.App.Services;
using RestaurantBusiness.App.ViewModels;
using System;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class AboutController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IRestaurantService _restaurantService;

        public AboutController(IReviewService reviewService, IRestaurantService restaurantService)
        {
            _reviewService = reviewService;
            _restaurantService = restaurantService;
        }

        public IActionResult Restaurants()
        {
            ViewBag.Title = "Рестораны";
            return View();
        }

        [Route("/Admin/About/EditRestaurants")]
        public async Task<IActionResult> EditRestaurants()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование ресторанов";
            var model = new RestaurantViewModel();
            model.Restaurants = await _restaurantService.GetAll();
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
                model.Restaurants = await _restaurantService.GetAll();
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/About/DeleteRestaurant")]
        public async Task DeleteRestaurant(Guid id)
        {
            await _restaurantService.DeleteAsync(id);
        }

        public IActionResult Service()
        {
            ViewBag.Title = "Обслуживание";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Контакты";
            return View();
        }

        public IActionResult Awards()
        {
            ViewBag.Title = "Награды";
            return View();
        }

        public IActionResult Staff()
        {
            ViewBag.Title = "Персонал";
            return View();
        }

        public IActionResult Reviews()
        {
            ViewBag.Title = "Отзывы";
            return View();
        }

        [Route("/Admin/About/EditReviews")]
        public async Task<IActionResult> EditReviews()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование отзывов";
            var model = new ReviewViewModel();
            model.Reviews = await _reviewService.GetAll();
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/About/EditReviews")]
        public async Task<IActionResult> EditReviews(ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _reviewService.AddAsync(model.Review);
                return Redirect("~/Admin/About/EditReviews");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование отзывов";
                model.Reviews = await _reviewService.GetAll();
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
