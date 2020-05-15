using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TodoCycle.DTO;
using TodoCycle.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoCycle.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var loggedInUserName = this.GetLoggedInUserName();
            var model = new JsonResult(loggedInUserName);
            return model;
        }

    }
}
