using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_CoreLayer.DTOs.Product;
using WebMarket_DataLayer.Entities;

namespace WebMarket_CoreLayer.Mapper
{
    public class ProductMapper
    {
        public static ProductDto MapToPoroductDto(Product p)
        {
            return new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Category = p.Category == null ? null : CategoryMapper.MapCateory(p.Category),
                SubCategoryId = p.SubCategoryId,
                SubCategory = p.SubCategory == null ? null : CategoryMapper.MapCateory(p.SubCategory),
                Price = p.Price,
                Description = p.Description,
                Slug = p.Slug,
                MetaDescription = p.MetaDescription,
                MetaTag = p.MetaTag,
                Brand = p.Brand == null ? null : BrandMapper.MapBrand(p.Brand)

            };
        }
        public static Product MapToCreatePoroductDto(CreatePoroductDto p)
        {
            return new Product()
            {

                Name = p.Name,
                CategoryId = p.CategoryId,
                SubCategoryId = p.SubCategoryId,
                Price = p.Price,
                Description = p.Description,
                Slug = p.Slug,
                MetaDescription = p.MetaDescription,
                MetaTag = p.MetaTag,
                BrandId = p.BrandId,
            };
        }
    }
}
