using StarWars.Common.Interfaces;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.DataAccess.Interfaces
{
    public interface IEpisodeRepository : IRepositoryDataReader<Episode>
    {
    }
}