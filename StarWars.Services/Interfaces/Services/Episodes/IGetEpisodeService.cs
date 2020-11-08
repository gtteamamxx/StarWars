using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Episodes
{
    public interface IGetEpisodeService
    {
        Task<EpisodeDTO> GetEpisodeByIdAsync(int id);
    }
}