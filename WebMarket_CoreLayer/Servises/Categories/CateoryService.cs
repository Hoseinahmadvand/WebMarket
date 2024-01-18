using WebBlog_Core.Utilities;
using WebMarket_CoreLayer.DTOs.Categories;
using WebMarket_CoreLayer.Mapper;
using WebMarket_CoreLayer.Utilities;
using WebMarket_DataLayer.Context;
using WebMarket_DataLayer.Entities;

namespace WebMarket_CoreLayer.Servises.Categories
{
    public class CateoryService : ICateoryService
    {
        private readonly WebMarketContext _context;
        public CateoryService(WebMarketContext context)
        {
            _context = context;
        }

        public OperationResult CreateCatgory(CreateCategoryDto command)
        {
            if(IsSlugExist(command.Slug))
                return OperationResult.Error("Slug Is Exist");

            var catgory = new Category() 
            {
                Name = command.Title,
                MetaDescription = command.MetaDescription,
                MetaTag = command.MetaTag,
                Slug=command.Slug.ToSlug(),
                ParentId=command.ParentId
            };

            _context.categories.Add(catgory);
            _context.SaveChanges();

            return OperationResult.Success();
        }

        public OperationResult EditCategory(EditCategoryDto command)
        {
            var category = _context.categories.FirstOrDefault(c=>c.Id==command.Id);

            if (category == null)
                return OperationResult.NotFound();

            if (command.Slug.ToSlug() != category.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("Slug Is Exist");

            category.Name = command.Title;
            category.MetaDescription = command.MetaDescription;
            category.MetaTag = command.MetaTag;
            category.Slug = command.Slug.ToSlug();

            _context.Update(category);
            _context.SaveChanges();
            return OperationResult.Success();
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.categories.Select(c => CategoryMapper.MapCateory(c)).ToList();
        }

        public List<CategoryDto> GetAllChildCategory(int parentId)
        {
            return _context.categories
                .Where(c => c.ParentId == parentId)
                .Select(c => CategoryMapper.MapCateory(c))
                .ToList();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            var category =_context.categories.FirstOrDefault(c=>c.Id == id);

            if(category == null)
                return null;

            return CategoryMapper.MapCateory( category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.categories.FirstOrDefault(c => c.Slug == slug);

            if (category == null)
                return null;

            return CategoryMapper.MapCateory(category);
        }

        public bool IsSlugExist(string slug)
        {
            return _context.categories.Any(c=>c.Slug == slug);
        }
    }
}
