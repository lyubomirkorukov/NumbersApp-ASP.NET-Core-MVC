using Microsoft.AspNetCore.Mvc;
using NumbersApp_ASP.NET_Core_MVC.Services;
using NumbersApp_ASP.NET_Core_MVC.ViewModels;
using System.Reflection;

namespace NumbersApp_ASP.NET_Core_MVC.Controllers
{
    public class NumbersController : Controller
    {
        private readonly INumbersService _numbersService;

        public NumbersController(INumbersService numbersService)
        {
            _numbersService = numbersService;
        }

        public IActionResult Index()
        {
            var model = new NumbersViewModel
            {
                Numbers = _numbersService.GetNumbers(),
                Sum = _numbersService.GetSum()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddNumber()
        {
            _numbersService.AddNumber();
            var model = new NumbersViewModel
            {
                Numbers = _numbersService.GetNumbers(),
                Sum = _numbersService.GetSum()
            };

            return PartialView("_NumbersList", model);
        }

        [HttpPost]
        public IActionResult ClearNumbers()
        {
            _numbersService.ClearNumbers();
            var model = new NumbersViewModel
            {
                Numbers = _numbersService.GetNumbers(),
                Sum = _numbersService.GetSum()
            };
            return PartialView("_NumbersList", model);
        }

        [HttpPost]
        public IActionResult SumNumbers()
        {
            _numbersService.SumNumbers();
            var model = new NumbersViewModel
            {
                Numbers = _numbersService.GetNumbers(),
                Sum = _numbersService.GetSum()
            };

            return PartialView("_NumbersList", model);
        }
    }
}
