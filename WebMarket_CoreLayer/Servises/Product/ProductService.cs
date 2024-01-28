using Microsoft.EntityFrameworkCore;
using WebBlog_Core.Utilities;
using WebMarket_CoreLayer.DTOs.Product;
using WebMarket_CoreLayer.Mapper;
using WebMarket_DataLayer.Context;

namespace WebMarket_CoreLayer.Servises.Product
{
    public class ProductService : IProductService
    {
        private readonly WebMarketContext _context;
        public ProductService(WebMarketContext context)
        {
            _context = context;
        }

        public OperationResult CreateProduct(CreatePoroductDto command)
        {
            if(IsSlugExist(command.Slug)==true)
                return OperationResult.Error();

            var product = ProductMapper.MapToCreatePoroductDto(command);
            _context.products.Add(product);
            _context.SaveChanges();
            return OperationResult.Success();

        }

        public OperationResult DeleteProduct(int id)
        {
            var prodoct=_context.products.FirstOrDefault(p => p.Id == id);
            _context.products.Remove(prodoct);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditProduct(EditPoroductDto command)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == command.Id);
            if(product == null)
                return OperationResult.NotFound();

            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.MetaDescription = command.MetaDescription;
            product.MetaTag = command.MetaTag;
            product.Slug = command.Slug;
            _context.products.Update(product);
            _context.SaveChanges();
            return OperationResult.Success();

        }

        public List<ProductDto> GetAllProduct()
        {
            var allProduct = _context.products
             .Include(p => p.Category)
             .Include(p => p.SubCategory)
             .Select(p => ProductMapper.MapToPoroductDto(p))
             .ToList();
         
            return allProduct;
        }

        //public ProductForViewDto GetAllProduct()
        //{
        //    var allProduct = _context.products
        //     .Include(p => p.Category)
        //     .Include(p => p.SubCategory)
        //     .Select(p => ProductMapper.MapToPoroductDto(p))
        //     .ToList();
        //    return new ProductForViewDto()
        //    {
        //        product = allProduct
        //    };
        //}

        public ProductDto GetProductBy(int id)
        {
            var product=_context.products.FirstOrDefault(p=>p.Id == id);
            if(null == product)
                return null;

            return ProductMapper.MapToPoroductDto( product);
        }

        public ProductDto GetProducttBy(string slug)
        {
            var product = _context.products.FirstOrDefault(p => p.Slug == slug);
            if (null == product)
                return null;

            return ProductMapper.MapToPoroductDto(product);
        }

        public bool IsSlugExist(string slug)
        {

            return _context.products.Any(c => c.Slug == slug);
        }

       
    }
}
