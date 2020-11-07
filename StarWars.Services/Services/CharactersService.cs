using AutoMapper;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharactersService(
            IMapper mapper,
            ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<List<CharacterDTO>> GetAllCharacters()
        {
            List<Character> characters = await _characterRepository.GetAllAsync();

            List<CharacterDTO> mappedCharacters = _mapper.Map<List<CharacterDTO>>(characters);

            return mappedCharacters;
        }
    }
}