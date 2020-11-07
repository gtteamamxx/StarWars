using AutoMapper;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Factories;
using StarWars.Services.Interfaces.Services;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly IGetAllCharactersFactory _getAllCharactersFactory;

        public CharactersService(IGetAllCharactersFactory getAllCharactersFactory)
        {
            _getAllCharactersFactory = getAllCharactersFactory;
        }

        public async Task<List<CharacterDTO>> GetAllCharactersAsync()
        {
            List<CharacterDTO> characters = await _getAllCharactersFactory.GetAllCharactersAsync();

            return characters;
        }

        public Task<CharacterDTO> GetCharacterByIdAsync(int characterId)
        {
            return null;
        }
    }
}