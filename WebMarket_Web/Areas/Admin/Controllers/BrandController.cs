using Microsoft.AspNetCore.Mvc;
using WebMarket_CoreLayer.DTOs.Brands;
using WebMarket_CoreLayer.Servises.Brands;
using WebMarket_Web.Areas.Admin.Models.Brand;

namespace WebMarket_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var brands = _brandService.GetAllBrand();
            return View(brands);
        }

        #region Create
        [Route("/admin/brand/create")]
        public IActionResult Create()
        {
            return View();
        } 
        

        [HttpPost("/admin/brand/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBrandViewModel createModel)
        {
            if(!ModelState.IsValid)
                return View(createModel);

            _brandService.CreateBrand(createModel.MapToDto());

            return RedirectToAction("index");
        }

        #endregion

        #region Edit
        [Route("/admin/brand/edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var brand = _brandService.GetBrandBy(Id);
            if (brand == null)
                return RedirectToAction("index");
            var model = new EditBrandViewModel()
            {
                Id = Id,
                Name = brand.Name,
                Description = brand.Description,
                Slug = brand.Slug,
                MetaDescription = brand.MetaDescription,
                MetaTag = brand.MetaTag,
                WebSiteLink= brand.WebSiteLink,
                Country = brand.Country
            };
            return View(model);
        }

        [HttpPost("/admin/brand/edit/{Id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, EditBrandViewModel editBrandVM)
        {
            _brandService.EditBrand(new EditBrandDto()
            {
                Name = editBrandVM.Name,
                Description= editBrandVM.Description,
                MetaDescription= editBrandVM.MetaDescription,
                Slug= editBrandVM.Slug,
                WebSiteLink = editBrandVM.WebSiteLink,
                Country = editBrandVM.Country,
                MetaTag= editBrandVM.MetaTag,
                Id = Id
            });

            return RedirectToAction("index");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _brandService.DeleteBrand(new DeleteBrandDto() { Id = id });
            return RedirectToAction("index");
        }

        #endregion
    }
}
