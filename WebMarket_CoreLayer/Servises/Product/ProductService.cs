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
            throw new NotImplementedException();
        }

        public OperationResult DeleteProduct(DeletePoroductDto command)
        {
            throw new NotImplementedException();
        }

        public OperationResult EditProduct(EditPoroductDto command)
        {
            throw new NotImplementedException();
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

        public ProductDto GetProductBy(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProducttBy(string slug)
        {
            throw new NotImplementedException();
        }

        public bool IsSlugExist(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
