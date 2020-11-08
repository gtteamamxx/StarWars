using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Characters
{
    public interface IGetAllCharactersService
    {
        Task<List<CharacterDTO>> GetAllCharactersAsync(IPagination pagination);
    }
}