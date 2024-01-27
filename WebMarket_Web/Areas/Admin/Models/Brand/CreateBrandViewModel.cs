using WebMarket_CoreLayer.DTOs.Brands;

namespace WebMarket_Web.Areas.Admin.Models.Brand
{
    public class CreateBrandViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string WebSiteLink { get; set; }


        public CreateBrandDto MapToDto()
        {
            return new CreateBrandDto()
            {
                Name = Name,
                Slug = Slug,
                MetaTag = MetaTag,
                MetaDescription = MetaDescription,
                Country = Country,
                Description = Description,
                WebSiteLink = WebSiteLink

            };
        }
    }
}
