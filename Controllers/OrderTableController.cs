using Microsoft.AspNetCore.Mvc;

namespace RestaurantBusiness.Controllers
{
    public class OrderTableController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Заказ столика";
            return View();
        }
    }
}
