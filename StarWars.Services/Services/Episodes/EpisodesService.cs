using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Episodes;
using StarWars.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Episodes
{
    public class EpisodesService : IEpisodesService
    {
        private readonly ICreateEpisodeService _createEpisodeService;
        private readonly IDeleteEpisodeService _deleteEpisodeService;
        private readonly IGetAllEpisodesService _getAllEpisodesService;
        private readonly IGetEpisodeService _getEpisodeService;
        private readonly IUpdateEpisodeService _updateEpisodeService;

        public EpisodesService(
            IGetAllEpisodesService getAllEpisodesService,
            IGetEpisodeService getEpisodeService,
            ICreateEpisodeService createEpisodeService,
            IUpdateEpisodeService updateEpisodeService,
            IDeleteEpisodeService deleteEpisodeService)
        {
            _getAllEpisodesService = getAllEpisodesService;
            _getEpisodeService = getEpisodeService;
            _createEpisodeService = createEpisodeService;
            _updateEpisodeService = updateEpisodeService;
            _deleteEpisodeService = deleteEpisodeService;
        }

        public Task<IEntityCreateResult> CreateEpisodeAsync(ICreateEpisodeModel createModel) => _createEpisodeService.CreateEpisodeAsync(createModel);

        public Task DeleteAsync(int id) => _deleteEpisodeService.DeleteAsync(id);

        public Task<List<EpisodeDTO>> GetAllEpisodesAsync(IPagination pagination) => _getAllEpisodesService.GetAllEpisodesAsync(pagination);

        public Task<EpisodeDTO> GetEpisodeByIdAsync(int characterId) => _getEpisodeService.GetEpisodeByIdAsync(characterId);

        public Task UpdateEpisodeAsync(IUpdateEpisodeModel updateModel) => _updateEpisodeService.UpdateEpisodeAsync(updateModel);
    }
}