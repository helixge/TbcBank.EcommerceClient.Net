using Example.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TbcBank.EcommerceClient;

namespace Example.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TbcBankEcommerceClient _tbcBankEcommerceClient;

        public HomeController(
            ILogger<HomeController> logger,
            TbcBankEcommerceClient tbcBankEcommerceClient
            )
        {
            _logger = logger;
            _tbcBankEcommerceClient = tbcBankEcommerceClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
