using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearning.Data;
using Elearning.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearning.Controllers
{
    [ServiceFilter(typeof(CheckSessionFilter))]
    public class AccountController : Controller
    {
        private readonly IDataRepository repo;

        public AccountController(IDataRepository repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index(string cert)
        {
            var user = await repo.GetUserbyId(HttpContext.Session.GetInt32("userid").Value).FirstOrDefaultAsync();
            if (!string.IsNullOrEmpty(cert))
            {
                ViewData["cert"] = "1";
            }
            return View(user);
        }
    }
}