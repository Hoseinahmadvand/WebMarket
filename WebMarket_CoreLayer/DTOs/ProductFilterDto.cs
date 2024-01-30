using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_CoreLayer.DTOs.Product;

namespace WebMarket_CoreLayer.DTOs
{
    public class ProductFilterDto
    {
        public List<ProductDto> products { get; set; }
        public int PageCount { get; set; }
        public ProductFilterParams FilterParams { get; set; }

        public class ProductFilterParams
        {
            public int PageId { get; set; }
            public string Name { get; set; }
            public string CategorySlug { get; set; }
            public int Take { get; set; }
        }
    }
}
