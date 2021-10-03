using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantBusiness.App.Services;
using RestaurantBusiness.App.ViewModels;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public MenuController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
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
                model.Categories = await _categoryService.GetAll();
                return View(model);
            }
        }

        [Route("/Admin/Menu/EditCategories")]
        public async Task<IActionResult> EditCategories()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование категорий";
            var model = new CategoryViewModel();
            model.Categories = await _categoryService.GetAll();
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Menu/DeleteCategory")]
        public async Task DeleteCategory(Guid id)
        {
            await _categoryService.DeleteAsync(id);
        }

        [Route("/Admin/Menu/EditProducts")]
        public async Task<IActionResult> EditProducts()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование блюд";
            var model = new ProductViewModel();
            model.Products = await _productService.GetAll();
            IEnumerable<Category> categories = await _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/Menu/EditProducts")]
        public async Task<IActionResult> EditProducts(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.GetByIdAsync(model.Product.Id) != null)
                {
                    await _productService.Update(model.Product, model.File);
                }
                else
                {
                    await _productService.AddAsync(model.Product, model.File);
                }
                return Redirect("~/Admin/Menu/EditProducts");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование блюд";
                model.Products = await _productService.GetAll();
                IEnumerable<Category> categories = await _categoryService.GetAll();
                ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Menu/DeleteProduct")]
        public async Task DeleteProduct(Guid id)
        {
            await _productService.DeleteAsync(id);
        }

    }
}
