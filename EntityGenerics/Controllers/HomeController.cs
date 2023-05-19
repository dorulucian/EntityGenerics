using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using EntityGenerics.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntityGenerics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericInterface<ProductViewModel> _productService;

        public HomeController(ILogger<HomeController> logger
            , IGenericInterface<ProductViewModel> productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var test = _productService.GetEntities();
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