using Microsoft.AspNetCore.Mvc;
using StarWars.Services.Interfaces;
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

        public CharactersController(ICharactersService charactersService)
        {
            _charactersService = charactersService;
        }

        [HttpPost]
        public IActionResult AddNewCharacter([FromBody] object model)
        {
            return Ok();
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(List<CharacterDTO>), 200)]
        public async Task<IActionResult> GetAllCharacters()
        {
            List<CharacterDTO> characters = await _charactersService.GetAllCharacters();

            return Ok(characters);
        }

        [HttpGet]
        public IActionResult GetById(int characterId)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCharacter([FromBody] object updateModel)
        {
            return Ok();
        }
    }
}