using System.Collections.Generic;
using System.Threading.Tasks;
using Categories.Core.DTO;

namespace Categories.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> GetAll();
        Task<CategoryReadDto> GetById(int id);
        Task<bool> Create(CategoryCreateDto category);
        Task<bool> Update(CategoryUpdateDto category);
    }
}