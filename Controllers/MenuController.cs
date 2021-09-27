using Microsoft.AspNetCore.Mvc;

namespace RestaurantBusiness.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Меню";
            return View();
        }
    }
}
