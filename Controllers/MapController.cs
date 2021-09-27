using Microsoft.AspNetCore.Mvc;

namespace RestaurantBusiness.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Схема проезда";
            return View();
        }
    }
}
