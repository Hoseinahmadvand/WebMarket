namespace WebMarket_Web.Areas.Admin.Models.Product
{
    public class EditProductViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
