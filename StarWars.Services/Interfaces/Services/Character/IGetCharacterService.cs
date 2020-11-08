using StarWars.Services.Interfaces.Models;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Character
{
    public interface IGetCharacterService
    {
        Task<CharacterDTO> GetCharacterByIdAsync(int id);
    }
}