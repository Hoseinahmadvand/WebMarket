using Microsoft.AspNetCore.Mvc;
using WebMarket_CoreLayer.DTOs.Categories;
using WebMarket_CoreLayer.Servises.Categories;
using WebMarket_Web.Areas.Admin.Models.Category;

namespace WebMarket_Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICateoryService _cateoryService;

        public CategoryController(ICateoryService cateoryService)
        {
            _cateoryService = cateoryService;
        }

        public IActionResult Index()
        {
            var categories = _cateoryService.GetAllCategory();
            return View(categories);
        }

        public IActionResult GetChildCategories(int parentId)
        {
            var childCategory = _cateoryService.GetAllChildCategory(parentId);
            return new JsonResult(childCategory);
        }

        // This Actions For Create New Category Or SubCategory
        // If ParentId == null Leader Category 
        // If ParentId != null Sub Category 
        #region Create

        [Route("/admin/category/create/{parentId?}")]
        public IActionResult Create(int? parentId)
        {
            return View();
        }

        [HttpPost("/admin/category/create/{parentId?}")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int? parentId, CreateCategoryViewModel createCategoryVM)
        {
            if (!ModelState.IsValid)
                return View(createCategoryVM);

            createCategoryVM.ParentId = parentId;
            var result = _cateoryService.CreateCatgory(createCategoryVM.MapToDto());

            return RedirectToAction("Index");
        }

        #endregion

        //  First Action Get Information By Input Id And Send To View
        // Second Action Post information To Db as View
        #region Edit
        [Route("/admin/category/edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var category = _cateoryService.GetCategoryBy(Id);
            if (category == null)
                return View("Error");

            var model = new EditCategoryViewModel()
                {
                Id = Id,
                Title = category.Title,
                Description = category.Description,
                Slug=category.Slug,
                MetaDescription=category.MetaDescription,
                MetaTag=category.MetaTag
            };

            return View(model);
        }

        [Route("/admin/category/edit/{Id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, EditCategoryViewModel editCategoryVM)
        {
            _cateoryService.EditCategory(new EditCategoryDto()
            {
                Id=Id,
                Title=editCategoryVM.Title,
                Description=editCategoryVM.Description,
                MetaTag =editCategoryVM.MetaTag,
                MetaDescription =editCategoryVM.MetaDescription,
                Slug =editCategoryVM.Slug
            });

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int Id)
        {
            _cateoryService.DeleteCategory(new DeleteCategoryDto() { Id = Id });
            return RedirectToAction("index");
        }

        #endregion
    }
}
