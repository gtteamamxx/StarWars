﻿using FluentValidation;
using FluentValidation.Results;
using StarWars.DataAccess.Interfaces;
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
    public class UpdateCharacterValidator : AbstractValidator<IUpdateCharacterModel>, IUpdateCharacterValidator
    {
        private readonly ICharacterRepository _characterRepository;

        public UpdateCharacterValidator(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;

            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<IUpdateCharacterModel> context, CancellationToken cancellation = default)
        {
            DataAccess.Model.Character? character = await _characterRepository.GetByOrDefaultAsync(x => x.Id == context.InstanceToValidate.Id);

            if (character == null) throw new EntityNotFoundException<DataAccess.Model.Character>(context.InstanceToValidate.Id);

            character = await _characterRepository.GetByOrDefaultAsync(x => x.Name == context.InstanceToValidate.Name);

            if (character != null) throw new CannoUpdateCharacterCharacterWIthSameNameAlreadyExistException(context.InstanceToValidate.Id, context.InstanceToValidate.Name);

            return await base.ValidateAsync(context, cancellation);
        }
    }
}