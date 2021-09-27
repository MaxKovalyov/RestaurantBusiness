using Microsoft.AspNetCore.Mvc;

namespace RestaurantBusiness.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Restaurants()
        {
            ViewBag.Title = "Рестораны";
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
    }
}
