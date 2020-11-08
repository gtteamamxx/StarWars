using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Characters
{
    public interface ICharactersService
    {
        Task<IEntityCreateResult> CreateCharacterAsync(ICreateCharacterModel createModel);

        Task DeleteAsync(int id);

        Task<List<CharacterDTO>> GetAllCharactersAsync(IPagination pagination);

        Task<CharacterDTO> GetCharacterByIdAsync(int characterId);

        Task UpdateCharacterAsync(IUpdateCharacterModel updateModel);
    }
}