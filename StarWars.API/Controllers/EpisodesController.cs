using Microsoft.AspNetCore.Mvc;
using StarWars.API.Models;
using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Services.Episodes;
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
        private readonly IDatabaseContext _databaseContext;
        private readonly IEpisodesService _episodesService;

        public EpisodesController(
            IEpisodesService episodesService,
            IDatabaseContext databaseContext)
        {
            _episodesService = episodesService;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddNewEpisode([FromBody] CreateEpisodeModel createModel)
        {
            IEntityCreateResult identity = await _episodesService.CreateEpisodeAsync(createModel);

            await _databaseContext.SaveChangesAsync();

            int id = identity.GetId();

            string uri = $"episodes/{id}";

            return Created(uri, id);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            await _episodesService.DeleteAsync(id);

            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(List<EpisodeDTO>), 200)]
        public async Task<IActionResult> GetAllEpisodes()
        {
            List<EpisodeDTO> episodes = await _episodesService.GetAllEpisodesAsync();

            return Ok(episodes);
        }

        [HttpGet("{episodeId}")]
        [ProducesResponseType(typeof(EpisodeDTO), 200)]
        public async Task<IActionResult> GetById(int episodeId)
        {
            EpisodeDTO episode = await _episodesService.GetEpisodeByIdAsync(episodeId);

            return Ok(episode);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateEpisode([FromBody] UpdateEpisodeModel updateModel)
        {
            await _episodesService.UpdateEpisodeAsync(updateModel);

            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}