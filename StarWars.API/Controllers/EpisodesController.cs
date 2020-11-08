using Microsoft.AspNetCore.Mvc;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewEpisode([FromBody] object createModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(List<EpisodeDTO>), 200)]
        public async Task<IActionResult> GetAllCharacters()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ProducesResponseType(typeof(EpisodeDTO), 200)]
        public async Task<IActionResult> GetById(int episodeId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateEpisode([FromBody] object updateModel)
        {
            throw new NotImplementedException();
        }
    }
}