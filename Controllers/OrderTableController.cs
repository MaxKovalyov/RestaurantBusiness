using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class OrderTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
