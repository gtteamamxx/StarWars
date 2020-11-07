using Microsoft.EntityFrameworkCore;
using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Common.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryDataReader<T> where T : class
    {
        private readonly IDatabaseContext _context;

        public RepositoryBase(IDatabaseContext context) => _context = context;

        public Task<List<T>> GetAllAsync() => _context.Set<T>().ToListAsync();

        public abstract Func<T, int> GetKeyExpression();
    }
}