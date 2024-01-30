using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMarket_CoreLayer.DTOs.MainPage;
using WebMarket_CoreLayer.Servises.Product;
using WebMarket_Web.Models;

namespace WebMarket_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMainPageService _productService;

        public HomeController(ILogger<HomeController> logger, IMainPageService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var main=_productService.GetData();
            
            return View(main);
        }

        public IActionResult ShowProdut(string slug)
        {
            var product=_productService.GetProductBySlug(slug);
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}