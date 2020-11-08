using AutoMapper;
using StarWars.DataAccess.Interfaces;
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
    public class GetCharacterService : IGetCharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public GetCharacterService(
            ICharacterRepository characterRepository,
            IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<CharacterDTO> GetCharacterByIdAsync(int id)
        {
            DataAccess.Model.Character? character = await _characterRepository.FindAsync(id, x => x.Episodes, x => x.Episodes.Select(y => y.Episode));

            return _mapper.Map<CharacterDTO>(character);
        }
    }
}