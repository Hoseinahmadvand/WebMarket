namespace WebMarket_Web.Areas.Admin.Models.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
    }
}
