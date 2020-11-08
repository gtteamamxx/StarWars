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

namespace StarWars.Services.Validators.Character
{
    public class CreateCharacterValidator : AbstractValidator<ICreateCharacterModel>, ICreateCharacterValidator
    {
        private readonly ICharacterRepository _characterRepository;

        public CreateCharacterValidator(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;

            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(64);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ICreateCharacterModel> context, CancellationToken cancellation = default)
        {
            await ValidateCharacterAlreadyExists(context);

            return await base.ValidateAsync(context, cancellation);
        }

        private async Task ValidateCharacterAlreadyExists(ValidationContext<ICreateCharacterModel> context)
        {
            DataAccess.Model.Character? character = await _characterRepository.GetByOrDefaultAsync(x => x.Name == context.InstanceToValidate.Name);

            if (character != null)
                throw new EntityAlreadyExistException(context.InstanceToValidate.Name);
        }
    }
}