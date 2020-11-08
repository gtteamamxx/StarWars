using Microsoft.EntityFrameworkCore;
using StarWars.Common.Extensions;
using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Common.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryDataReader<T> where T : class
    {
        private readonly IDatabaseContext _context;

        public RepositoryBase(IDatabaseContext context) => _context = context;

        public IEntityCreateResult Add(T entity)
        {
            _context.Set<T>().Add(entity);

            return new EntityCreateResult<T>(entity, GetKeyExpression().Compile());
        }

        public async Task<T> FindAsync(int id, params Expression<Func<T, object>>[] navigationProperties)
        {
            T element = await PrepareQuery(
                query: _context.Set<T>().Where(GetKeyExpression().ShouldEqual(id)),
                navigationProperties
            ).SingleOrDefaultAsync()
                ?? throw new Exception($"{typeof(T).Name} with id: {id} not found");

            return element;
        }

        public Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, navigationProperties);

            return query.ToListAsync();
        }

        public Task<T> GetByOrDefaultAsync(Expression<Func<T, bool>> condition) => _context.Set<T>().FirstOrDefaultAsync(condition);

        public abstract Expression<Func<T, int>> GetKeyExpression();

        private static IQueryable<T> PrepareQuery(IQueryable<T> query, Expression<Func<T, object>>[] navigationProperties)
        {
            if (navigationProperties.Length == 0) return query;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                if (navigationProperty.GetExpressionPath() is string expressionPath)
                    query = query.Include(expressionPath);
                else
                    query.Include(navigationProperty);
            }

            return query;
        }
    }
}