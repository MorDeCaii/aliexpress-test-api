using System.Collections.Generic;
using System.Threading.Tasks;

namespace Categories.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> Create(TEntity entitiy);
        Task<bool> Update(TEntity entitiy);
        Task<bool> Delete(int  id);   
    }
}