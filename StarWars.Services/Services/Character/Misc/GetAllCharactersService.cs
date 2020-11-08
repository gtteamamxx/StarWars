using AutoMapper;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Character;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Character.Misc
{
    public class GetAllCharactersService : IGetAllCharactersService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public GetAllCharactersService(
            ICharacterRepository characterRepository,
            IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<List<CharacterDTO>> GetAllCharactersAsync()
        {
            var allCharacters = await _characterRepository.GetAllAsync(x => x.Episodes, x => x.Episodes.Select(y => y.Episode));

            return _mapper.Map<List<CharacterDTO>>(allCharacters);
        }
    }
}