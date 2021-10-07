using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusiness.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("/Admin/Login/Index")]
        public IActionResult Index()
        {
            ViewBag.Admin = true;
            ViewBag.Title = "Авторизация админа";
            return View();
        }

        [HttpPost]
        [Route("/Admin/Login/Index")]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var md5 = MD5.Create();
                if(
                    Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(model.Login))) == "ISMvKXpXpadDiUoOSoAfww=="
                    && 
                    Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(model.Password))) == "inEqxCyxL1grB+eW/E/O6g=="
                   )
                {
                    await Authenticate(model.Login);

                    return Redirect("~/Admin/Home/EditNews");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            ViewBag.Admin = true;
            ViewBag.Title = "Авторизация админа";
            return View(model);
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Home/Index");
        }
    }
}
