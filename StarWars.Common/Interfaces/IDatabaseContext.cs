using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Common.Interfaces
{
    public interface IDatabaseContext
    {
        Task SaveChangesAsync();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}