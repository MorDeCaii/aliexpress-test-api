using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Categories.Core.DTO;
using Categories.Core.Entities;
using Categories.Core.Repositories;
using Categories.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Categories.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public async Task<IEnumerable<CategoryReadDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var result = BuildTree(categories).ToList();
            return result;
        }

        public async Task<CategoryReadDto> GetById(int id)
        {
            var categories = await _categoryRepository.GetByIdWithSubcategories(id);
            
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            
            var result = new CategoryReadDto
            {
                Id = id,
                Name = category.Name,
                Subcategories = BuildTree(categories, id).ToList()
            };
            
            return result;
        }

        public async Task<bool> Create(CategoryCreateDto category)
        {
            var parent = await _categoryRepository.GetByIdAsync(category.ParentId);
            if (parent == null)
            {
                return false;
            }
            
            var row = new Category()
            {
                Id = 0,
                Name = category.Name,
                ParentId = category.ParentId
            };

            var result = await _categoryRepository.Create(row);
            return result;
        }

        public async Task<bool> Update(CategoryUpdateDto category)
        {
            var parent = await _categoryRepository.GetByIdAsync(category.ParentId);
            if (parent == null)
            {
                return false;
            }
            
            var row = new Category()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            };

            var result = await _categoryRepository.Update(row);
            return result;
        }
        
        private IEnumerable<CategoryReadDto> BuildTree(IEnumerable<Category> list, int parentId = 0)
        {
            return list.Where(c => c.ParentId == parentId)
                .Select(c => new CategoryReadDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Subcategories = BuildTree(list, c.Id).ToList()
                });
        }
    }
}