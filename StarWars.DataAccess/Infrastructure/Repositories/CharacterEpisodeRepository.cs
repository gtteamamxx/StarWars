using Microsoft.EntityFrameworkCore;
using StarWars.Common.Concrete;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.DataAccess.Infrastructure.Repositories
{
    public class CharacterEpisodeRepository : RepositoryBase<CharacterEpisode>, ICharacterEpisodeRepository
    {
        public CharacterEpisodeRepository(IDatabaseContext context) : base(context)
        {
        }

        public override Expression<Func<CharacterEpisode, int>> GetKeyExpression() => x => x.Id;
    }
}