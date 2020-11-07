using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services
{
    public interface ICharactersService
    {
        Task<List<CharacterDTO>> GetAllCharactersAsync();

        Task<CharacterDTO> GetCharacterByIdAsync(int characterId);
    }
}