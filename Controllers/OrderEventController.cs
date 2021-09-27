using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class OrderEventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
