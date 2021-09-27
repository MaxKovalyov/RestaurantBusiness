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

        [Route("/Admin/OrderEvent/EditOrders")]
        public IActionResult EditOrders()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование заказов мероприятий";
            return View();
        }
    }
}
