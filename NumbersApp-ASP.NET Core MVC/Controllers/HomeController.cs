using Microsoft.AspNetCore.Mvc;
using NumbersApp_ASP.NET_Core_MVC.ViewModels;
using System.Diagnostics;

namespace NumbersApp_ASP.NET_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
