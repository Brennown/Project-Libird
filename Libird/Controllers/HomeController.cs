using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Libird.Models.ViewModels;
using Libird.Models.Domain;

namespace Libird.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(User user)
        {
            ViewBag.Name = user.Name;
            ViewBag.LastName = user.LastName;
            return View();
        }
    }
}
