using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket_CoreLayer.DTOs.Brands
{
    public class BrandDto: EditBrandDto
    {
    }

    public class CreateBrandDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string WebSiteLink { get; set; }
    }
    
    public class EditBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string WebSiteLink { get; set; }
    }

    public class DeleteBrandDto
    {
        public int Id { get; set; }
    }

}
