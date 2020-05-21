using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearning.Data;
using Elearning.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearning.Controllers
{
    public class AuthController : Controller
    {
        private readonly IDataRepository repo;

        public AuthController(IDataRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto user)
        {
            var userfromdb = await repo.GetUserLogin(user.UserName, user.Password);
            if (userfromdb != null)
            {
                if (userfromdb.Active)
                {
                    HttpContext.Session.SetInt32("userid", userfromdb.Id);
                    HttpContext.Session.SetString("role", userfromdb.Role);
                    if (user.RememberMe)
                    {
                        var cookieopt = new CookieOptions()
                        {
                            Expires = DateTime.Now.AddDays(1)
                        };
                        HttpContext.Response.Cookies.Delete("Log");
                        HttpContext.Response.Cookies.Append("Log", user.Password + "#" + userfromdb.Id, cookieopt);
                    }
                    return RedirectToAction("Index", "Home");
                }else
                    ViewData["msg"] = "*Kullanıcınız aktif değil";

            }
            else
            {
                ViewData["msg"] = "*Kullanıcı adı veya şifre yanlış";
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Response.Cookies.Delete("Log");
            return View("Index");
        }
    }
}