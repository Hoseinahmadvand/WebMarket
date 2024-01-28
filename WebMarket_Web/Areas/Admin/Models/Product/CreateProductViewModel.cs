using WebMarket_CoreLayer.DTOs.Product;

namespace WebMarket_Web.Areas.Admin.Models.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int? SubCategoryId { get; set; }

        public CreatePoroductDto MapToDto()
        {
            return new CreatePoroductDto()
            {
                Name = Name,
                Slug = Slug,
                MetaDescription = MetaDescription,
                MetaTag = MetaTag,
                Price = Price,
                Description = Description,
                CategoryId = CategoryId,
                SubCategoryId = SubCategoryId,
                BrandId = BrandId,
            };
        }
    }
}
