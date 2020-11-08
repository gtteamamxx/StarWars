using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Services.Episodes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Episodes.Misc
{
    public class DeleteEpisodeService : IDeleteEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public DeleteEpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task DeleteAsync(int id)
        {
            Episode? episodeToDelete = await _episodeRepository.FindAsync(id);

            _episodeRepository.Delete(episodeToDelete);
        }
    }
}