using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantBusiness.App.Services;
using RestaurantBusiness.App.ViewModels;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        private readonly int _pageSize = 3;

        public MenuController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Меню";
            var model = new MenuViewModel()
            {
                Categories = await _categoryService.GetAll(),
                Products = await _productService.GetAll()
            };
            return View(model);
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
                IEnumerable<Category> categories = await _categoryService.GetAll();
                var countItems = categories.Count();
                var items = categories.Skip((model.PageModel.PageNumber - 1) * _pageSize).Take(_pageSize).ToList();
                var pageModel = new PageViewModel(countItems, model.PageModel.PageNumber, _pageSize);
                model.Categories = items;
                model.PageModel = pageModel;
                return View(model);
            }
        }

        [Route("/Admin/Menu/EditCategories")]
        public async Task<IActionResult> EditCategories(int page = 1)
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование категорий";
            IEnumerable<Category> categories = await _categoryService.GetAll();
            var countItems = categories.Count();
            var items = categories.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _pageSize);
            var model = new CategoryViewModel()
            {
                Categories = items,
                PageModel = pageModel
            };
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Menu/DeleteCategory")]
        public async Task DeleteCategory(Guid id)
        {
            await _categoryService.DeleteAsync(id);
        }

        [Route("/Admin/Menu/EditProducts")]
        public async Task<IActionResult> EditProducts(int page = 1)
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование блюд";
            IEnumerable<Product> products = await _productService.GetAll();
            var countItems = products.Count();
            var items = products.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _pageSize);
            var model = new ProductViewModel()
            {
                Products = items,
                PageModel = pageModel
            };
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
                IEnumerable<Product> products = await _productService.GetAll();
                var countItems = products.Count();
                var items = products.Skip((model.PageModel.PageNumber - 1) * _pageSize).Take(_pageSize).ToList();
                var pageModel = new PageViewModel(countItems, model.PageModel.PageNumber, _pageSize);
                model.Products = items;
                model.PageModel = pageModel;
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
