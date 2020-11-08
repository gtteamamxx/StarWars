using StarWars.Services.Interfaces.Models;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Episodes
{
    public interface IGetAllEpisodesService
    {
        Task<List<EpisodeDTO>> GetAllEpisodesAsync();
    }
}