using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Character;
using StarWars.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Character
{
    public class CharactersService : ICharactersService
    {
        private readonly ICreateCharacterService _createCharacterService;
        private readonly IDeleteCharacterService _deleteCharacterService;
        private readonly IGetAllCharactersService _getAllCharactersService;
        private readonly IGetCharacterService _getCharacterService;
        private readonly IUpdateCharacterService _updateCharacterService;

        public CharactersService(
            IGetAllCharactersService getAllCharactersService,
            IGetCharacterService getCharacterService,
            ICreateCharacterService createCharacterService,
            IUpdateCharacterService updateCharacterService,
            IDeleteCharacterService deleteCharacterService)
        {
            _getAllCharactersService = getAllCharactersService;
            _getCharacterService = getCharacterService;
            _createCharacterService = createCharacterService;
            _updateCharacterService = updateCharacterService;
            _deleteCharacterService = deleteCharacterService;
        }

        public Task<IEntityCreateResult> CreateCharacterAsync(ICreateCharacterModel createModel) => _createCharacterService.CreateCharacterAsync(createModel);

        public Task DeleteAsync(int id) => _deleteCharacterService.DeleteAsync(id);

        public Task<List<CharacterDTO>> GetAllCharactersAsync() => _getAllCharactersService.GetAllCharactersAsync();

        public Task<CharacterDTO> GetCharacterByIdAsync(int characterId) => _getCharacterService.GetCharacterByIdAsync(characterId);

        public Task UpdateCharacterAsync(IUpdateCharacterModel updateModel) => _updateCharacterService.UpdateCharacterAsync(updateModel);
    }
}