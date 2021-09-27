using Microsoft.AspNetCore.Mvc;

namespace RestaurantBusiness.Controllers
{
    public class SitemapController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Карта сайта";
            return View();
        }
    }
}
