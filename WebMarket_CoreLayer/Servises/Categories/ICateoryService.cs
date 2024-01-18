using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog_Core.Utilities;
using WebMarket_CoreLayer.DTOs.Categories;

namespace WebMarket_CoreLayer.Servises.Categories
{
    public interface ICateoryService
    {
        OperationResult CreateCatgory(CreateCategoryDto command);
        OperationResult EditCategory(EditCategoryDto command);
        List<CategoryDto> GetAllCategory();
        List<CategoryDto> GetAllChildCategory(int parentId);
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);
        bool IsSlugExist(string slug);
    }
}
