using AutoMapper;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Services.Episodes;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Episodes.Misc
{
    public class GetAllEpisodesService : IGetAllEpisodesService
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public GetAllEpisodesService(
            IEpisodeRepository episodeRepository,
            IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        public async Task<List<EpisodeDTO>> GetAllEpisodesAsync()
        {
            List<Episode>? allEpisodes = await _episodeRepository.GetAllAsync(x => x.CharactersInEpisode, x => x.CharactersInEpisode.Select(y => y.Character));

            return _mapper.Map<List<EpisodeDTO>>(allEpisodes);
        }
    }
}