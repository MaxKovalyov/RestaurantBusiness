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

        [Route("/Admin/Menu/EditCategories")]
        public IActionResult EditCategories()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование категорий";
            return View();
        }

        [Route("/Admin/Menu/EditProducts")]
        public IActionResult EditProducts()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование блюд";
            return View();
        }
    }
}
