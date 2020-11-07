using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Factories
{
    public interface IGetAllCharactersFactory
    {
        Task<List<CharacterDTO>> GetAllCharactersAsync();
    }
}