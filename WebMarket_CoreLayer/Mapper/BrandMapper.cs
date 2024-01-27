using WebMarket_CoreLayer.DTOs.Brands;
using WebMarket_DataLayer.Entities;

namespace WebMarket_CoreLayer.Mapper
{
    public class BrandMapper
    {
        public static BrandDto MapBrand(Brand b)
        {
            return new BrandDto()
            {
                Id = b.Id,
                Name = b.Name,
                MetaDescription = b.MetaDescription,
                MetaTag = b.MetaTag,
                Slug = b.Slug,
                Description = b.Description,
                Country = b.Country,
                WebSiteLink = b.WebSiteLink
            };
        }
    }
}
