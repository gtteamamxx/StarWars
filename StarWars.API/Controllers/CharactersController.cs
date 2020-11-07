using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public IActionResult AddNewCharacter([FromBody] object model)
        {
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAllCharacters()
        {
            return Ok(new[] { new { Test = "test" } });
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