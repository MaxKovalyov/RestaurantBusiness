using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class OrderEventController : Controller
    {
        private readonly IOrderEventService _orderEventService;
        private readonly IRestaurantService _restaurantService;
        private readonly IProductService _productService;

        private readonly int _pageSize = 3;

        public OrderEventController(IOrderEventService orderEventService, IRestaurantService restaurantService, IProductService productService)
        {
            _orderEventService = orderEventService;
            _restaurantService = restaurantService;
            _productService = productService;
        }

        [Route("/Admin/OrderEvent/EditOrders")]
        public async Task<IActionResult> EditOrders(int page = 1)
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Редактирование заказов мероприятий";
            IEnumerable<OrderEvent> eventOrders = await _orderEventService.GetAll();
            var countItems = eventOrders.Count();
            var items = eventOrders.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var pageModel = new PageViewModel(countItems, page, _pageSize);
            var model = new OrderEventViewModel()
            {
                Products = await _productService.GetAll(),
                EventOrders = items,
                PageModel = pageModel
            };
            IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
            ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/OrderEvent/EditOrders")]
        public async Task<IActionResult> EditOrders(OrderEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderEventService.Update(model.OrderEvent, model.OrderedProducts);
                return Redirect("~/Admin/OrderEvent/EditOrders");
            }
            else
            {
                ViewBag.Admin = true;
                ViewBag.Title = "Редактирование заказов столиков";
                IEnumerable<OrderEvent> eventOrders = await _orderEventService.GetAll();
                var countItems = eventOrders.Count();
                var items = eventOrders.Take(_pageSize).ToList();
                var pageModel = new PageViewModel(countItems, 1, _pageSize);
                model.EventOrders = items;
                model.PageModel = pageModel;
                model.Products = await _productService.GetAll();
                IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
                ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
                return View(model);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Заказ мероприятия";
            var model = new OrderEventViewModel()
            {
                Products = await _productService.GetAll()
            };
            IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
            ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(OrderEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderEventService.AddAsync(model.OrderEvent, model.OrderedProducts);
                return Redirect("~/OrderEvent/Index");
            }
            else
            {
                model.Products = await _productService.GetAll();
                IEnumerable<Restaurant> restaurants = await _restaurantService.GetAll();
                ViewBag.Restaurants = new SelectList(restaurants, "Id", "Title");
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/OrderEvent/DeleteOrder")]
        public async Task DeleteOrder(Guid id)
        {
            await _orderEventService.DeleteAsync(id);
        }
    }
}
