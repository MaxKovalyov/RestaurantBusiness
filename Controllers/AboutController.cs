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

        public AboutController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Restaurants()
        {
            ViewBag.Title = "Рестораны";
            return View();
        }

        [Route("/Admin/About/EditRestaurants")]
        public IActionResult EditRestaurants()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование ресторанов";
            return View();
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
