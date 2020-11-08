using FluentValidation;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Episodes;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Episodes.Misc
{
    public class UpdateEpisodeService : IUpdateEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IUpdateEpisodeValidator _updateEpisodeValidator;

        public UpdateEpisodeService(
            IUpdateEpisodeValidator updateEpisodeValidator,
            IEpisodeRepository episodeRepository)
        {
            _updateEpisodeValidator = updateEpisodeValidator;
            _episodeRepository = episodeRepository;
        }

        public async Task UpdateEpisodeAsync(IUpdateEpisodeModel updateModel)
        {
            if (updateModel == null) throw new ArgumentNullException(nameof(updateModel));

            await _updateEpisodeValidator.ValidateAndThrowAsync(updateModel);

            Episode episodeToUpdate = await _episodeRepository.FindAsync(updateModel.Id);

            episodeToUpdate.Name = updateModel.Name;
        }
    }
}