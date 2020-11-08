using FluentValidation;
using FluentValidation.Results;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Exceptions;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Episodes;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Services.Validators.Characters
{
    public class CreateCharacterValidator : AbstractValidator<ICreateCharacterModel>, ICreateCharacterValidator
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IEpisodeRepository _episodeRepository;

        public CreateCharacterValidator(
            ICharacterRepository characterRepository,
            IEpisodeRepository episodeRepository)
        {
            _characterRepository = characterRepository;
            _episodeRepository = episodeRepository;

            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(64);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ICreateCharacterModel> context, CancellationToken cancellation = default)
        {
            await ValidateCharacterAlreadyExists(context);

            await ValidateEpisodesExistence(context);

            return await base.ValidateAsync(context, cancellation);
        }

        private async Task ValidateCharacterAlreadyExists(ValidationContext<ICreateCharacterModel> context)
        {
            Character character = await _characterRepository.GetByOrDefaultAsync(x => x.Name == context.InstanceToValidate.Name);

            if (character != null) throw new EntityAlreadyExistException(context.InstanceToValidate.Name);
        }

        private async Task ValidateEpisodesExistence(ValidationContext<ICreateCharacterModel> context)
        {
            List<string> episodeNames = context.InstanceToValidate.Episodes;

            foreach (string episodeNameToAssign in episodeNames)
            {
                Episode? episode = await _episodeRepository.GetByOrDefaultAsync(x => x.Name == episodeNameToAssign);

                if (episode == null) throw new CharacterCannotBeCreatedWithNotExistedEpisodeException(episodeNameToAssign);
            }
        }
    }
}