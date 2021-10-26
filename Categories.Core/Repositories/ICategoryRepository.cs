using System.Collections.Generic;
using System.Threading.Tasks;
using Categories.Core.Entities;

namespace Categories.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetByIdWithSubcategories(int id);
    }
}