using Elearning.Controllers;
using Elearning.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elearning.Utility
{
    public class CheckSessionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userid = context.HttpContext.Session.GetInt32("userid");
            if (userid==null || userid==0)
            {
                try
                {
                    var cookies = context.HttpContext.Request.Cookies["Log"].Split('#');
                    var repo = context.HttpContext.RequestServices.GetService<IDataRepository>();
                    var user =await repo.GetUserLoginbyId(Convert.ToInt32(cookies[1]), cookies[0]);
                    userid = user.Id;
                    if (userid == null || userid == 0)
                    {
                        var controller = (Controller)context.Controller;
                        context.Result = controller.RedirectToAction("Index", "Auth");
                    }
                    else
                    {
                        context.HttpContext.Session.SetInt32("userid", userid.Value);
                        context.HttpContext.Session.SetString("role", user.Role);
                        var resultcontext = await next();
                    }
                    }
                catch
                {
                    var controller = (Controller)context.Controller;
                    context.Result = controller.RedirectToAction("Index", "Auth");
                }

            }
            else
            {
                var resultcontext = await next();
            }

        }
    }
}
