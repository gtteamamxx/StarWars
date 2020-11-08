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

        Task<T> FindAsync(int id, params Expression<Func<T, object>>[] navigationProperties);

        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);

        Task<T> GetByOrDefaultAsync(Expression<Func<T, bool>> condition);
    }
}