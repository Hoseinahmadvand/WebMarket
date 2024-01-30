using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_CoreLayer.DTOs.Product;
using WebMarket_CoreLayer.Mapper;
using WebMarket_DataLayer.Context;
using static WebMarket_CoreLayer.DTOs.ProductFilterDto;

namespace WebMarket_CoreLayer.DTOs.MainPage
{
    public interface IMainPageService
    {
        MainPageDto GetData();
        ProductFilterDto GetProductByFilter(ProductFilterParams filterParams);
        ProductDto GetProductBySlug(string slug);
        List<ProductDto> GetRelatedProducts(int groupId);

    }
    public class MainPageService : IMainPageService
    {
        private readonly WebMarketContext _context;
        public MainPageService(WebMarketContext context)
        {
            _context = context;
        }

        public MainPageDto GetData()
        {
            var categories = _context.categories
             .OrderByDescending(d => d.Id)
             .Take(6)
             .Include(c => c.CategoryProduct)
             .Include(c => c.SubCategoryProduct)
             .Select(category => new MainPageCategoryDto()
             {
                 Title = category.Name,
                 Slug = category.Slug,
                 PostChild = category.CategoryProduct.Count + category.SubCategoryProduct.Count,
                 IsMainCategory = category.ParentId == null
             }).ToList();

            var products = _context.products
              .OrderByDescending(d => d.Id)
              .Include(c => c.Category)
              .Include(c => c.SubCategory)
              .Select(p => ProductMapper.MapToPoroductDto(p)).ToList();

            var brands=_context.brands
                .OrderByDescending(b=>b.Id)
                .Include(p=>p.BrandProduct)
                .Select(brands=>new MainPageBrandDto()
                {
                    Title=brands.Name,
                    Slug=brands.Slug,
                }).ToList();

            return new MainPageDto()
            {
                Categories = categories,
                Products = products,
                Brands = brands
            };
        }

        public ProductFilterDto GetProductByFilter(ProductFilterParams filterParams)
        {
            var result = _context.products
             .Include(c => c.Category)
             .Include(s => s.SubCategory)
             .Include(b => b.Brand)
             .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterParams.CategorySlug))
                result = result.Where(r => r.Category.Slug == filterParams.CategorySlug || r.SubCategory.Slug == filterParams.CategorySlug);

            if (!string.IsNullOrWhiteSpace(filterParams.Name))
                result = result.Where(p => p.Name.Contains(filterParams.Name));

            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var pageCount = result.Count() / filterParams.Take;

            return new ProductFilterDto()
            {
                products = result.Skip(skip).Take(filterParams.Take)
                .Select(p => ProductMapper.MapToPoroductDto(p)).ToList(),
                FilterParams = filterParams,
                PageCount = pageCount
            };
        }

        public ProductDto GetProductBySlug(string slug)
        {
            var products = _context.products
           .Include(c => c.Category)
           .Include(s => s.SubCategory)
           .Include(s => s.Brand)
           .FirstOrDefault(c => c.Slug == slug);

            if (products == null)
                return null;

            return ProductMapper.MapToPoroductDto(products);
        }

        public List<ProductDto> GetRelatedProducts(int groupId)
        {
            var related = _context.products
                 .Where(p => p.CategoryId == groupId || p.SubCategoryId == groupId)
                 .Take(6)
                 .Select(post => ProductMapper.MapToPoroductDto(post))
                 .ToList();

            return related;
        }
    }
}
