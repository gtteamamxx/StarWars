using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Episodes
{
    public interface IEpisodesService
    {
        Task<IEntityCreateResult> CreateEpisodeAsync(ICreateEpisodeModel createModel);

        Task DeleteAsync(int id);

        Task<List<EpisodeDTO>> GetAllEpisodesAsync();

        Task<EpisodeDTO> GetEpisodeByIdAsync(int characterId);

        Task UpdateEpisodeAsync(IUpdateEpisodeModel updateModel);
    }
}