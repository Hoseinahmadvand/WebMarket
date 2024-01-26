using WebBlog_Core.Utilities;
using WebMarket_CoreLayer.DTOs.Brands;
using WebMarket_CoreLayer.Mapper;
using WebMarket_CoreLayer.Utilities;
using WebMarket_DataLayer.Context;
using WebMarket_DataLayer.Entities;

namespace WebMarket_CoreLayer.Servises.Brands
{
    public interface IBrandService
    {
        OperationResult CreateBrand(CreateBrandDto command);
        OperationResult EditBrand(EditBrandDto command);
        OperationResult DeleteBrand(DeleteBrandDto command);
        List<BrandDto> GetAllBrand();
        BrandDto GetBrandBy(int id);
        BrandDto GetBrandBy(string slug);
        bool IsSlugExist(string slug);
    }
    public class BrandService : IBrandService
    {
        private readonly WebMarketContext _context;

        public BrandService(WebMarketContext context)
        {
            _context = context;
        }


        public OperationResult CreateBrand(CreateBrandDto command)
        {
            if (IsSlugExist(command.Slug))
                return OperationResult.Error("Slug Is Exist");


           var brand = new Brand()
           {
               Name = command.Name,
               Description = command.Description,
               MetaDescription = command.MetaDescription,
               MetaTag=command.MetaTag,
               Slug = command.Slug.ToSlug(),
               Country = command.Country,
               WebSiteLink = command.WebSiteLink
           };

            _context.brands.Add(brand);
            _context.SaveChanges();

            return OperationResult.Success();
        }

        public OperationResult DeleteBrand(DeleteBrandDto command)
        {
            var brand = _context.brands.FirstOrDefault(b => b.Id == command.Id);
            if (brand == null)
                return OperationResult.NotFound();

            _context.brands.Remove(brand);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditBrand(EditBrandDto command)
        {
            var brand=_context.brands.FirstOrDefault(b=>b.Id==command.Id);
            if (brand == null)
                return OperationResult.NotFound();

            if (command.Slug.ToSlug() != brand.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("Slug Is Exist");

            brand.Name = command.Name;
            brand.MetaDescription = command.MetaDescription;
            brand.MetaTag = command.MetaTag;
            brand.Slug = command.Slug.ToSlug();
            brand.Description = command.Description;
            brand.Country= command.Country;
            brand.WebSiteLink = command.WebSiteLink;

            _context.brands.Update(brand);
            _context.SaveChanges();

            return OperationResult.Success();
        }

        public List<BrandDto> GetAllBrand()
        {
            return _context.brands.Select(b => BrandMapper.MapBrand(b)).ToList();
        }

        public BrandDto GetBrandBy(int id)
        {
            var brand = _context.brands.FirstOrDefault(b => b.Id == id);
            if (brand == null)
                return null;
            return BrandMapper.MapBrand(brand);
        }

        public BrandDto GetBrandBy(string slug)
        {
            var brand = _context.brands.FirstOrDefault(b => b.Slug == slug);
            if (brand == null)
                return null;
            return BrandMapper.MapBrand(brand);
        }

        public bool IsSlugExist(string slug)
        {
            return _context.brands.Any(c => c.Slug == slug);
        }
    }
}
