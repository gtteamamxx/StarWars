using FluentValidation;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Factories.Characters;
using StarWars.Services.Interfaces.Factories.Episodes;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Services.Characters;
using StarWars.Services.Interfaces.Services.Episodes;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Services.Episodes.Misc
{
    public class CreateEpisodeService : ICreateEpisodeService
    {
        private readonly ICreateEpisodeFactory _createEpisodeFactory;
        private readonly ICreateEpisodeValidator _createEpisodeValidator;
        private readonly IEpisodeRepository _episodeRepository;

        public CreateEpisodeService(
            IEpisodeRepository episodeRepository,
            ICreateEpisodeValidator createEpisodeValidator,
            ICreateEpisodeFactory createEpisodeFactory)
        {
            _episodeRepository = episodeRepository;
            _createEpisodeValidator = createEpisodeValidator;
            _createEpisodeFactory = createEpisodeFactory;
        }

        public async Task<IEntityCreateResult> CreateEpisodeAsync(ICreateEpisodeModel createModel)
        {
            if (createModel is null) throw new ArgumentNullException(nameof(createModel));

            await _createEpisodeValidator.ValidateAndThrowAsync(createModel);

            Episode episodeToAdd = _createEpisodeFactory.Create(createModel);

            IEntityCreateResult identity = _episodeRepository.Add(episodeToAdd);

            return identity;
        }
    }
}