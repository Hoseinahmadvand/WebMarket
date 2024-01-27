using Microsoft.AspNetCore.Mvc;
using WebMarket_CoreLayer.Servises.Product;

namespace WebMarket_Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProduct();
            return View(products);
        }
    }
}
