using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_CoreLayer.DTOs.Categories;
using WebMarket_DataLayer.Entities;

namespace WebMarket_CoreLayer.Mapper
{
    public class CategoryMapper
    {
        public static CategoryDto MapCateory(Category c)
        {
            return new CategoryDto()
            {
                Id = c.Id,
                Title = c.Name,
                MetaDescription = c.MetaDescription,
                MetaTag = c.MetaTag,
                ParentId = c.ParentId,
                Slug = c.Slug,
                Description=c.Description
            };
        }
    }
}
