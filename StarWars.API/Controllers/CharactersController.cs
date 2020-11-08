using Microsoft.AspNetCore.Mvc;
using StarWars.API.Models;
using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Character;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersService _charactersService;
        private readonly IDatabaseContext _databaseContext;

        public CharactersController(
            ICharactersService charactersService,
            IDatabaseContext databaseContext)
        {
            _charactersService = charactersService;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewCharacter([FromBody] CreateCharacterModel createModel)
        {
            IEntityCreateResult identity = await _charactersService.CreateCharacterAsync(createModel);

            await _databaseContext.SaveChangesAsync();

            int id = identity.GetId();

            string uri = $"characters/{id}";

            return Created(uri, id);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            await _charactersService.DeleteAsync(id);

            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(List<CharacterDTO>), 200)]
        public async Task<IActionResult> GetAllCharacters()
        {
            List<CharacterDTO> characters = await _charactersService.GetAllCharactersAsync();

            return Ok(characters);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CharacterDTO>), 200)]
        public async Task<IActionResult> GetById(int characterId)
        {
            CharacterDTO character = await _charactersService.GetCharacterByIdAsync(characterId);

            return Ok(character);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateCharacter([FromBody] UpdateCharacterModel updateModel)
        {
            await _charactersService.UpdateCharacterAsync(updateModel);

            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}