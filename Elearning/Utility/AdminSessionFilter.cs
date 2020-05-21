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
    public class AdminSessionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var role = context.HttpContext.Session.GetString("role");
            if (string.IsNullOrEmpty(role))
            {
                try
                {
                    var cookies = context.HttpContext.Request.Cookies["Log"].Split('#');
                    var repo = context.HttpContext.RequestServices.GetService<IDataRepository>();
                    var user = await repo.GetUserLoginbyId(Convert.ToInt32(cookies[1]), cookies[0]);
                    role = user.Role;

                    if (role == null)
                    {
                        var controller = (Controller)context.Controller;
                        context.Result = controller.RedirectToAction("Index", "Auth");
                    }
                    else if (role == SD.Roles.Admin.ToString())
                    {
                        context.HttpContext.Session.SetInt32("userid", user.Id);
                        context.HttpContext.Session.SetString("role", user.Role);
                        var resultcontext = await next();

                    }
                    else
                    {
                        var controller = (Controller)context.Controller;
                        context.Result = controller.RedirectToAction("Index", "Home");
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
                if (role == SD.Roles.Admin.ToString())
                {
                    var resultcontext = await next();
                }
                else
                {
                    var controller = (Controller)context.Controller;
                    context.Result = controller.RedirectToAction("Index", "Home");
                }
            }

        }
    }
}
