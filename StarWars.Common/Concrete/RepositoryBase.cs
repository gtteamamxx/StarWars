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

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<T> FindAsync(int id, params Expression<Func<T, object>>[] navigationProperties)
        {
            T element = _context.Set<T>().Local.FirstOrDefault(GetKeyExpression().ShouldEqual(id).Compile());

            if (element == null)
                element = await PrepareQuery(
                    query: _context.Set<T>().Where(GetKeyExpression().ShouldEqual(id)),
                    navigationProperties
                ).SingleOrDefaultAsync();

            return element ?? throw new Exception($"{typeof(T).Name} with id: {id} not found"); ;
        }

        public Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, navigationProperties);

            return query.ToListAsync();
        }

        public Task<List<T>> GetAllByOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            List<T> elements = _context.Set<T>().Local.Where(condition.Compile()).ToList();

            if (elements != null) return Task.FromResult<List<T>>(elements);

            return _context.Set<T>().Where(condition).ToListAsync();
        }

        public Task<T> GetByOrDefaultAsync(Expression<Func<T, bool>> condition)
        {
            T element = _context.Set<T>().Local.FirstOrDefault(condition.Compile());

            if (element != null) return Task.FromResult<T>(element);

            return _context.Set<T>().FirstOrDefaultAsync(condition);
        }

        public abstract Expression<Func<T, int>> GetKeyExpression();

        private IQueryable<T> PrepareQuery(IQueryable<T> query, Expression<Func<T, object>>[] navigationProperties)
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