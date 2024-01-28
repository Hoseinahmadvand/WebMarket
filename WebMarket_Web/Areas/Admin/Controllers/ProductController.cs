using Microsoft.AspNetCore.Mvc;
using WebMarket_CoreLayer.DTOs.Product;
using WebMarket_CoreLayer.Servises.Product;
using WebMarket_Web.Areas.Admin.Models.Product;

namespace WebMarket_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductViewModel createProduct)
        {
            if (!ModelState.IsValid)
                return View();

            var result = _productService.CreateProduct(createProduct.MapToDto());

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var product = _productService.GetProductBy(Id);
            if (product == null)
                return View("Error");
            var model = new EditProductViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                MetaDescription = product.MetaDescription,
                MetaTag = product.MetaTag,
                Price = product.Price,
                Slug = product.Slug
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, EditProductViewModel editProduct)
        {
            _productService.EditProduct(new EditPoroductDto()
            {
                Id = Id,
                Name = editProduct.Name,
                MetaDescription= editProduct.MetaDescription,
                MetaTag= editProduct.MetaTag,
                Description = editProduct.Description,
                Price  = editProduct.Price,
                Slug= editProduct.Slug
            });
            return RedirectToAction("index");
        }

        public IActionResult Delete(int Id)
        {
            _productService.DeleteProduct(Id);
            return RedirectToAction("Index");
        }
    }
}
