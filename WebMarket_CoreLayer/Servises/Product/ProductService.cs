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
    }
}
