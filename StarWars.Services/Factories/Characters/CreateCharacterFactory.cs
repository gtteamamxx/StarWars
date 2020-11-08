using Microsoft.EntityFrameworkCore.Internal;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Factories.Characters;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Factories.Characters
{
    public class CreateCharacterFactory : ICreateCharacterFactory
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IEpisodeRepository _episodeRepository;

        public CreateCharacterFactory(
            IEpisodeRepository episodeRepository,
            ICharacterRepository characterRepository)
        {
            _episodeRepository = episodeRepository;
            _characterRepository = characterRepository;
        }

        public async Task<Character> CreateAsync(ICreateCharacterModel createModel)
        {
            List<Episode> episodes = await _episodeRepository.GetAllByOrDefaultAsync(x => createModel.Episodes.Contains(x.Name));

            List<Character> friends = await _characterRepository.GetAllByOrDefaultAsync(x => createModel.Friends.Contains(x.Name));

            return new Character()
            {
                Name = createModel.Name,
                Friends = friends.Select(x => new CharacterFriend()
                {
                    FriendCharacterId = x.Id
                }).ToList(),
                Episodes = episodes.Select(x => new CharacterEpisode()
                {
                    EpisodeId = x.Id
                }).ToList()
            };
        }
    }
}