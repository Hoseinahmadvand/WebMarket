using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_CoreLayer.DTOs.Product;

namespace WebMarket_CoreLayer.DTOs
{
    public class MainPageDto
    {
        public List<ProductDto> Products { get; set; }
        public List<MainPageBrandDto> Brands { get; set; }
        public List<MainPageCategoryDto> Categories { get; set; }
    }
    public class MainPageCategoryDto
    {
        public bool IsMainCategory { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public int PostChild { get; set; }
    }
    public class MainPageBrandDto
    {
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}
