using WebMarket_CoreLayer.DTOs.Categories;

namespace WebMarket_Web.Areas.Admin.Models.Category
{
    public class CreateCategoryViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        public CreateCategoryDto MapToDto()
        {
            return new CreateCategoryDto()
            {
                Title = Title,
                Slug = Slug,
                MetaTag = MetaTag,
                MetaDescription = MetaDescription,
                ParentId = ParentId,
                Description = Description
            };
        }
    }
}
