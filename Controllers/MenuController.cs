using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.App.Services;
using RestaurantBusiness.App.ViewModels;
using RestaurantBusiness.Models;
using System;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoryService _categoryService;

        public MenuController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Меню";
            return View();
        }

        [HttpPost]
        [Route("/Admin/Menu/EditCategories")]
        public async Task<IActionResult> EditCategories(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryService.GetByIdAsync(model.Category.Id) != null)
                {
                    await _categoryService.Update(model.Category);
                }
                else
                {
                    await _categoryService.AddAsync(model.Category);
                }
                return Redirect("~/Admin/Menu/EditCategories");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование категорий";
                model.Categories = await _categoryService.GetAllCategory();
                return View(model);
            }
        }

        [Route("/Admin/Menu/EditCategories")]
        public async Task<IActionResult> EditCategories()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование категорий";
            var model = new CategoryViewModel();
            model.Categories = await _categoryService.GetAllCategory();
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Menu/DeleteCategory")]
        public async Task DeleteCategory(Guid id)
        {
            await _categoryService.DeleteAsync(id);
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
