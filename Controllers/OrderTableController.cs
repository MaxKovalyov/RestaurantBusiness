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

        [Route("/Admin/OrderTable/EditOrders")]
        public IActionResult EditOrders()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование заказов столиков";
            return View();
        }
    }
}
