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
    public class OrderTableController : Controller
    {
        private readonly IOrderTableService _orderTableService;
        private readonly IRestaurantService _restaurantService;

        public OrderTableController(IOrderTableService orderTableService, IRestaurantService restaurantService)
        {
            _orderTableService = orderTableService;
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Заказ столика";
            return View();
        }

        [Route("/Admin/OrderTable/EditOrders")]
        public async Task<IActionResult> EditOrders()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование заказов столиков";
            var model = new OrderTableViewModel();
            model.TableOrders = await _orderTableService.GetAll();
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
                model.TableOrders = await _orderTableService.GetAll();
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
                return Redirect("~/Admin/OrderTable/EditOrders");
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
