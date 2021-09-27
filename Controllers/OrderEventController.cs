using Microsoft.AspNetCore.Mvc;

namespace RestaurantBusiness.Controllers
{
    public class OrderEventController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Заказ мероприятия";
            return View();
        }
    }
}
