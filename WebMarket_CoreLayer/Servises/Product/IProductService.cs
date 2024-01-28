using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog_Core.Utilities;
using WebMarket_CoreLayer.DTOs.Product;

namespace WebMarket_CoreLayer.Servises.Product
{
    public interface IProductService
    {
        OperationResult CreateProduct(CreatePoroductDto command);
        OperationResult EditProduct(EditPoroductDto command);
        OperationResult DeleteProduct(int id);
       //ProductForViewDto GetAllProduct();
       List<ProductDto> GetAllProduct();
        ProductDto GetProductBy(int id);
        ProductDto GetProducttBy(string slug);
        bool IsSlugExist(string slug);
    }
}
