using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Common.Interfaces
{
    public interface IRepositoryDataReader<T>
    {
        IEntityCreateResult Add(T entity);

        void Delete(T entity);

        Task<T> FindAsync(int id, params Expression<Func<T, object>>[] navigationProperties);

        Task<List<T>> GetAllAsPageAsync(int pageIndex, int pageSize, params Expression<Func<T, object>>[] navigationProperties);

        Task<List<T>> GetAllByOrDefaultAsync(Expression<Func<T, bool>> conditio);

        Task<T> GetByOrDefaultAsync(Expression<Func<T, bool>> condition);
    }
}