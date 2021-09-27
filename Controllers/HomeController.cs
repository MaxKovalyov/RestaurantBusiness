using Microsoft.AspNetCore.Mvc;

namespace RestaurantBusiness.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            ViewBag.Title = "Главная страница";
            return View();
        }

        [Route("/Admin/Home/EditNews")]
        public IActionResult EditNews()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование новостей";
            return View();
        }


    }
}
