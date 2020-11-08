using AutoMapper;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Episodes;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Episodes.Misc
{
    public class GetEpisodeService : IGetEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public GetEpisodeService(
            IEpisodeRepository episodeRepository,
            IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        public async Task<EpisodeDTO> GetEpisodeByIdAsync(int id)
        {
            Episode episode = await _episodeRepository.FindAsync(id,
                x => x.CharactersInEpisode, x => x.CharactersInEpisode.Select(y => y.Character)
            );

            return _mapper.Map<EpisodeDTO>(episode);
        }
    }
}