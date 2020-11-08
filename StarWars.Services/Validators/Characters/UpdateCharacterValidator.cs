using FluentValidation;
using FluentValidation.Results;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Exceptions;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Services.Validators.Characters
{
    public class UpdateCharacterValidator : AbstractValidator<IUpdateCharacterModel>, IUpdateCharacterValidator
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IEpisodeRepository _episodeRepository;

        public UpdateCharacterValidator(
            ICharacterRepository characterRepository,
            IEpisodeRepository episodeRepository)
        {
            _characterRepository = characterRepository;
            _episodeRepository = episodeRepository;

            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<IUpdateCharacterModel> context, CancellationToken cancellation = default)
        {
            await ValidateCharacterExist(context);

            await ValidateCharacterExistWithName(context);

            await ValidateAllEpisodesExist(context);

            await ValidateAllFriendsExist(context);

            return await base.ValidateAsync(context, cancellation);
        }

        private async Task ValidateAllEpisodesExist(ValidationContext<IUpdateCharacterModel> context)
        {
            List<string> episodesToAssign = context.InstanceToValidate.Episodes;

            foreach (string episodeNameToAssign in episodesToAssign)
            {
                Episode? episode = await _episodeRepository.GetByOrDefaultAsync(x => x.Name == episodeNameToAssign);

                if (episode == null) throw new CannotUpdateCharacterWithNotExistedEpisodeException(episodeNameToAssign);
            }
        }

        private async Task ValidateAllFriendsExist(ValidationContext<IUpdateCharacterModel> context)
        {
            List<string> friendsToAssign = context.InstanceToValidate.Friends;

            foreach (string friendNameToAssign in friendsToAssign)
            {
                Character? character = await _characterRepository.GetByOrDefaultAsync(x => x.Name == friendNameToAssign);

                if (character == null) throw new CannotUpdateCharacterWithNotExistedFriendException(friendNameToAssign);

                else if (context.InstanceToValidate.Name == character.Name) throw new CharacterCannotBeFriendWithSelfException();

            }
        }

        private async Task ValidateCharacterExist(ValidationContext<IUpdateCharacterModel> context)
        {
            Character? character = await _characterRepository.GetByOrDefaultAsync(x => x.Id == context.InstanceToValidate.Id);

            if (character == null) throw new EntityNotFoundException<Character>(context.InstanceToValidate.Id);
        }

        private async Task ValidateCharacterExistWithName(ValidationContext<IUpdateCharacterModel> context)
        {
            Character? character = await _characterRepository.GetByOrDefaultAsync(x => x.Name == context.InstanceToValidate.Name && x.Id != context.InstanceToValidate.Id);

            if (character != null) throw new CannotUpdateCharacterCharacterWithSameNameAlreadyExistException(context.InstanceToValidate.Id, context.InstanceToValidate.Name);
        }
    }
}