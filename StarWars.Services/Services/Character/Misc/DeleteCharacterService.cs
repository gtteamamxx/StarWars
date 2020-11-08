using StarWars.DataAccess.Interfaces;
using StarWars.Services.Interfaces.Services.Character;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Character.Misc
{
    public class DeleteCharacterService : IDeleteCharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public DeleteCharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task DeleteAsync(int id)
        {
            DataAccess.Model.Character? characterToDelete = await _characterRepository.FindAsync(id);

            _characterRepository.Delete(characterToDelete);
        }
    }
}