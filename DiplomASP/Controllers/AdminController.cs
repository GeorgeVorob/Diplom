using DiplomASP.Models;
using DiplomASP.Models.ViewModels;
using DiplomCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataProviderService _data;

        public AdminController(ILogger<HomeController> logger, DataProviderService data)
        {
            _logger = logger;
            _data = data;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}