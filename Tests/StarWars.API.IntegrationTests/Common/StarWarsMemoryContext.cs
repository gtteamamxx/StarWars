using Microsoft.EntityFrameworkCore;
using StarWars.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.API.IntegrationTests.Common
{
    public class StarWarsMemoryContext : StarWarsContext
    {
        public StarWarsMemoryContext(DbContextOptions<StarWarsContext> options) : base(options)
        {
        }
    }
}