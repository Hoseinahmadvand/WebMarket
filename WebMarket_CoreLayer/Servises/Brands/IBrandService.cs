using WebBlog_Core.Utilities;
using WebMarket_CoreLayer.DTOs.Brands;

namespace WebMarket_CoreLayer.Servises.Brands
{
    public interface IBrandService
    {
        OperationResult CreateBrand(CreateBrandDto command);
        OperationResult EditBrand(EditBrandDto command);
        OperationResult DeleteBrand(DeleteBrandDto command);
        List<BrandDto> GetAllBrand();
        BrandDto GetBrandBy(int id);
        BrandDto GetBrandBy(string slug);
        bool IsSlugExist(string slug);
    }
}
