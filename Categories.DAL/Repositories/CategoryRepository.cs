using System.Collections.Generic;
using System.Threading.Tasks;
using Categories.Core;
using Categories.Core.Repositories;
using Categories.Core.Entities;
using Dapper;

namespace Categories.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnectionFactory _connection;

        public CategoryRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }
        
        public async Task<Category> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM categories WHERE \"Id\" = @id";

            using (var connection = _connection.CreateConnection())
            {
                var category = await connection.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
                return category;
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var sql = "SELECT * FROM categories";

            using (var connection = _connection.CreateConnection())
            {
                var categories = await connection.QueryAsync<Category>(sql);
                return categories;
            }
        }

        public async Task<bool> Create(Category category)
        {
            var sql = @"INSERT INTO categories
                        VALUES (DEFAULT, @Name, @ParentId)";
            
            using (var connection = _connection.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, new
                {
                    Name = category.Name,
                    ParentId = category.ParentId
                });
                
                return result != 0;
            }
        }

        public async Task<bool> Update(Category category)
        {
            var sql = @"UPDATE categories 
                        SET ""Name"" = @Name,
                            ""ParentId"" = @ParentId
                        WHERE ""Id"" = @Id";

            using (var connection = _connection.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, new
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId = category.ParentId
                });
                
                return result != 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var sql = @"DELETE FROM categories 
                        WHERE ""Id"" = @Id";
            
            using (var connection = _connection.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                if (result != 0)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<IEnumerable<Category>> GetByIdWithSubcategories(int id)
        {
            var sql = @"WITH RECURSIVE r AS (
                            SELECT * FROM categories
                            WHERE ""Id"" = @id

                            UNION ALL

                            SELECT categories.""Id"", categories.""Name"", categories.""ParentId"" FROM categories
                            JOIN r ON categories.""ParentId"" = r.""Id""
                        )
                        SELECT * FROM r";

            using (var connection = _connection.CreateConnection())
            {
                var categories = await connection.QueryAsync<Category>(sql, new { Id = id });
                return categories;
            }
        }
    }
}