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
        private readonly IGetAllCharactersService _getAllCharactersService;
        private readonly IGetCharacterService _getCharacterService;

        public CharactersService(
            IGetAllCharactersService getAllCharactersService,
            IGetCharacterService getCharacterService,
            ICreateCharacterService createCharacterService)
        {
            _getAllCharactersService = getAllCharactersService;
            _getCharacterService = getCharacterService;
            _createCharacterService = createCharacterService;
        }

        public Task<IEntityCreateResult> CreateCharacterAsync(ICreateCharacterModel createModel) => _createCharacterService.CreateCharacterAsync(createModel);

        public Task<List<CharacterDTO>> GetAllCharactersAsync() => _getAllCharactersService.GetAllCharactersAsync();

        public Task<CharacterDTO> GetCharacterByIdAsync(int characterId) => _getCharacterService.GetCharacterByIdAsync(characterId);
    }
}