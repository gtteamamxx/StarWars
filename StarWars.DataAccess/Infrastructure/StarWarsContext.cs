using Microsoft.EntityFrameworkCore;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.DataAccess.Infrastructure
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }

        public virtual DbSet<Episode> Episodes { get; set; }
    }
}