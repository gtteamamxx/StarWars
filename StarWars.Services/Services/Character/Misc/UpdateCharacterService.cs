using StarWars.DataAccess.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Character;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Character.Misc
{
    public class UpdateCharacterService : IUpdateCharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IUpdateCharacterValidator _updateCharacterValidator;

        public UpdateCharacterService(
            IUpdateCharacterValidator updateCharacterValidator,
            ICharacterRepository characterRepository)
        {
            _updateCharacterValidator = updateCharacterValidator;
            _characterRepository = characterRepository;
        }

        public async Task UpdateCharacterAsync(IUpdateCharacterModel updateModel)
        {
            if (updateModel == null) throw new ArgumentNullException(nameof(updateModel));

            await _updateCharacterValidator.ValidateAsync(updateModel);

            DataAccess.Model.Character? characterToUpdate = await _characterRepository.FindAsync(updateModel.Id);

            characterToUpdate.Name = updateModel.Name;
        }
    }
}