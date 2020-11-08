using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Character
{
    public interface ICharactersService
    {
        Task<IEntityCreateResult> CreateCharacterAsync(ICreateCharacterModel createModel);

        Task<List<CharacterDTO>> GetAllCharactersAsync();

        Task<CharacterDTO> GetCharacterByIdAsync(int characterId);
    }
}