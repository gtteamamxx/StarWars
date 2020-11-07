using Microsoft.EntityFrameworkCore;
using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Common.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryDataReader<T> where T : class
    {
        private readonly IDatabaseContext _context;

        public RepositoryBase(IDatabaseContext context) => _context = context;

        public async Task<T> FindAsync(int id, params Expression<Func<T, object>>[] navigationProperties)
        {
            T element = await PrepareQuery(
                query: _context.Set<T>().Where(GetFilterExpression(id)),
                navigationProperties
            ).FirstOrDefaultAsync()

                ?? throw new Exception($"{typeof(T).Name} with id: ${id} not found");

            return element;
        }

        public Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, navigationProperties);

            return query.ToListAsync();
        }

        public abstract Expression<Func<T, bool>> GetFilterExpression(int id);

        private static IQueryable<T> PrepareQuery(IQueryable<T> query, Expression<Func<T, object>>[] navigationProperties)
        {
            if (navigationProperties.Length == 0) return query;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                List<Expression> arguments = (navigationProperty.Body as MethodCallExpression)
                    ?.Arguments
                    ?.ToList();

                if (arguments != null)
                {
                    string path = string.Join(".", arguments.Select(x =>
                    {
                        if (x is MemberExpression memberExpression)
                            return memberExpression.Member.Name;
                        else if (x is LambdaExpression lambdaExpression)
                            return (lambdaExpression.Body as MemberExpression).Member.Name;
                        return string.Empty;
                    }));

                    query = query.Include(path);
                }
                else query = query.Include(navigationProperty);
            }

            return query;
        }
    }
}