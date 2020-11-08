using FluentValidation;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Characters;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Characters.Misc
{
    public class UpdateCharacterService : IUpdateCharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IUpdateCharacterValidator _updateCharacterValidator;

        public UpdateCharacterService(
            IUpdateCharacterValidator updateCharacterValidator,
            ICharacterRepository characterRepository,
            IEpisodeRepository episodeRepository)
        {
            _updateCharacterValidator = updateCharacterValidator;
            _characterRepository = characterRepository;
            _episodeRepository = episodeRepository;
        }

        public async Task UpdateCharacterAsync(IUpdateCharacterModel updateModel)
        {
            if (updateModel == null) throw new ArgumentNullException(nameof(updateModel));

            await _updateCharacterValidator.ValidateAndThrowAsync(updateModel);

            Character characterToUpdate = await _characterRepository.FindAsync(updateModel.Id, x => x.Episodes);

            characterToUpdate.Name = updateModel.Name;

            await SetCharacterEpisodesAsync(characterToUpdate, updateModel.Episodes);

            await SetCharacterFriendsAsync(characterToUpdate, updateModel.Friends);
        }

        private async Task SetCharacterEpisodesAsync(Character characterToUpdate, List<string> episodes)
        {
            List<Episode> episodesToAssign = await _episodeRepository.GetAllByOrDefaultAsync(x => episodes.Contains(x.Name));

            HashSet<int> episodesToAssignIds = episodesToAssign.Select(x => x.Id).ToHashSet();

            List<CharacterEpisode>? episodesToRemove
                = characterToUpdate.Episodes.Where(x => !episodesToAssignIds.Contains(x.EpisodeId)).ToList();

            List<CharacterEpisode>? episodesToAdd = episodesToAssignIds.Where(x => !characterToUpdate.Episodes.Any(y => y.EpisodeId == x))
                .Select(episodeId => new CharacterEpisode()
                {
                    CharacterId = characterToUpdate.Id,
                    EpisodeId = episodeId
                }).ToList();

            episodesToRemove.ForEach(x => characterToUpdate.Episodes.Remove(x));

            episodesToAdd.ForEach(x => characterToUpdate.Episodes.Add(x));
        }

        private async Task SetCharacterFriendsAsync(Character characterToUpdate, List<string> friends)
        {
            List<Character> friendsToAssign = await _characterRepository.GetAllByOrDefaultAsync(x => friends.Contains(x.Name));

            HashSet<int> friendsToAssignIds = friendsToAssign.Select(x => x.Id).ToHashSet();

            List<CharacterFriend>? friendsToRemove
                = characterToUpdate.Friends.Where(x => !friendsToAssignIds.Contains(x.FriendCharacterId)).ToList();

            List<CharacterFriend>? friendsToAdd = friendsToAssignIds.Where(x => !characterToUpdate.Episodes.Any(y => y.EpisodeId == x))
                .Select(friendId => new CharacterFriend()
                {
                    CharacterId = characterToUpdate.Id,
                    FriendCharacterId = friendId
                }).ToList();

            friendsToRemove.ForEach(x => characterToUpdate.Friends.Remove(x));

            friendsToAdd.ForEach(x => characterToUpdate.Friends.Add(x));
        }
    }
}