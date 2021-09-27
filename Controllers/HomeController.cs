﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ViewResult Index()
        {
            ViewData["Title"] = "Главная страница";
            ViewData["Page"] = "Главная";
            return View();
        }


    }
}
