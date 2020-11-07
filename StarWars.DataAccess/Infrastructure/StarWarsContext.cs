using Microsoft.EntityFrameworkCore;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.DataAccess.Infrastructure
{
    public class StarWarsContext : DbContext, IDatabaseContext
    {
        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; } = default!;

        public virtual DbSet<Episode> Episodes { get; set; } = default!;

        public Task SaveChangesAsync() => base.SaveChangesAsync();
    }
}