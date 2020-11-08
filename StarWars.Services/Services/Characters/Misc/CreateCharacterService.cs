using FluentValidation;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Factories.Characters;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Characters;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Characters.Misc
{
    public class CreateCharacterService : ICreateCharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ICreateCharacterFactory _createCharacterFactory;
        private readonly ICreateCharacterValidator _createCharacterValidator;

        public CreateCharacterService(
            ICharacterRepository characterRepository,
            ICreateCharacterValidator createCharacterValidator,
            ICreateCharacterFactory createCharacterFactory)
        {
            _characterRepository = characterRepository;
            _createCharacterValidator = createCharacterValidator;
            _createCharacterFactory = createCharacterFactory;
        }

        public async Task<IEntityCreateResult> CreateCharacterAsync(ICreateCharacterModel createModel)
        {
            if (createModel is null) throw new ArgumentNullException(nameof(createModel));

            await _createCharacterValidator.ValidateAndThrowAsync(createModel);

            Character characterToAdd = await _createCharacterFactory.CreateAsync(createModel);

            IEntityCreateResult identity = _characterRepository.Add(characterToAdd);

            return identity;
        }
    }
}