using StarWars.Common.Interfaces;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.DataAccess.Interfaces
{
    public interface ICharacterEpisodeRepository : IRepositoryDataReader<CharacterEpisode>
    {
    }
}