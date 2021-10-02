using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.App.Services;
using RestaurantBusiness.App.ViewModels;
using System;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;
        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Главная страница";
            return View();
        }

        [Route("/Admin/Home/EditNews")]
        public async Task<IActionResult> EditNews()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование новостей";
            var model = new NewsViewModel();
            model.News = await _newsService.GetAllNews();
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Home/EditNews")]
        public async Task<IActionResult> EditCategories(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _newsService.GetByIdAsync(model.OneNews.Id) != null)
                {
                    await _newsService.Update(model.OneNews);
                }
                else
                {
                    await _newsService.AddAsync(model.OneNews);
                }
                return Redirect("~/Admin/Home/EditNews");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование новостей";
                model.News = await _newsService.GetAllNews();
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Home/DeleteNews")]
        public async Task DeleteCategory(Guid id)
        {
            await _newsService.DeleteAsync(id);
        }
    }
}
