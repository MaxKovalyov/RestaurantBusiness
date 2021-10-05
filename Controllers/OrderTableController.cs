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
    public class OrderTableController : Controller
    {
        private readonly IOrderTableService _orderTableService;
        private readonly IRestaurantService _restaurantService;

        private readonly int _pageSize = 5;

        public OrderTableController(IOrderTableService orderTableService, IRestaurantService restaurantService)
        {
            _orderTableService = orderTableService;
            _restaurantService = restaurantService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Заказ столика";
            IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
            ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
            return View();
        }

        [Route("/Admin/OrderTable/EditOrders")]
        public async Task<IActionResult> EditOrders(int page = 1)
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование заказов столиков";
            IEnumerable<OrderTable> tableOrders = await _orderTableService.GetAll();
            var countItems = tableOrders.Count();
            var items = tableOrders.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _pageSize);
            var model = new OrderTableViewModel()
            {
                TableOrders = items,
                PageModel = pageModel
            };
            IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
            ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/OrderTable/EditOrders")]
        public async Task<IActionResult> EditOrders(OrderTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderTableService.Update(model.OrderTable);
                return Redirect("~/Admin/OrderTable/EditOrders");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование заказов столиков";
                IEnumerable<OrderTable> tableOrders = await _orderTableService.GetAll();
                var countItems = tableOrders.Count();
                var items = tableOrders.Take(_pageSize).ToList();
                var pageModel = new PageViewModel(countItems, 1, _pageSize);
                model.TableOrders = items;
                model.PageModel = pageModel;
                IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
                ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderTable model)
        {
            if (ModelState.IsValid)
            {
                await _orderTableService.AddAsync(model);
                return Redirect("~/OrderTable/Index");
            }
            else
            {
                IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
                ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/OrderTable/DeleteOrder")]
        public async Task DeleteOrder(Guid id)
        {
            await _orderTableService.DeleteAsync(id);
        }
    }
}
