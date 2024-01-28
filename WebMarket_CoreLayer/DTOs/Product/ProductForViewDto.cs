using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_CoreLayer.DTOs.Categories;

namespace WebMarket_CoreLayer.DTOs.Product
{
    public class ProductForViewDto
    {
        public List<ProductDto> product { get; set; }
       // public CategoryDto   category { get; set; }
    }
}
