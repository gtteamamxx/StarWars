using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces
{
    public interface ICharactersService
    {
        Task<List<CharacterDTO>> GetAllCharacters();
    }
}