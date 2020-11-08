using FluentValidation;
using FluentValidation.Results;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using StarWars.Services.Exceptions;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Services.Validators.Characters
{
    public class UpdateEpisodeValidator : AbstractValidator<IUpdateEpisodeModel>, IUpdateEpisodeValidator
    {
        private readonly IEpisodeRepository _episodeRepository;

        public UpdateEpisodeValidator(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;

            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<IUpdateEpisodeModel> context, CancellationToken cancellation = default)
        {
            Episode? episode = await _episodeRepository.GetByOrDefaultAsync(x => x.Id == context.InstanceToValidate.Id);

            if (episode == null) throw new EntityNotFoundException<Episode>(context.InstanceToValidate.Id);

            episode = await _episodeRepository.GetByOrDefaultAsync(x => x.Name == context.InstanceToValidate.Name);

            if (episode != null) throw new CannoUpdateEpisodeEpisodeWithSameNameAlreadyExistException(context.InstanceToValidate.Id, context.InstanceToValidate.Name);

            return await base.ValidateAsync(context, cancellation);
        }
    }
}