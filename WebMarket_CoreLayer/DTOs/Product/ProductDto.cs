using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_CoreLayer.DTOs.Brands;
using WebMarket_CoreLayer.DTOs.Categories;

namespace WebMarket_CoreLayer.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public CategoryDto SubCategory { get; set; }
        //public BrandDto Brand { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
    }

     public class CreatePoroductDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int BrandId { get; set; }
    }

     public class EditPoroductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

     public class DeletePoroductDto
    {
    }


}
