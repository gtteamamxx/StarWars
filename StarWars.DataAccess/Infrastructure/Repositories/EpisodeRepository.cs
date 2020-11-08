using StarWars.Common.Concrete;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StarWars.DataAccess.Infrastructure.Repositories
{
    public class EpisodeRepository : RepositoryBase<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(IDatabaseContext context) : base(context)
        {
        }

        public override Expression<Func<Episode, int>> GetKeyExpression() => x => x.Id;
    }
}