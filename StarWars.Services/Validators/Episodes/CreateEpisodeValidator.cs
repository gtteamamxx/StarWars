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

namespace StarWars.Services.Validators.Episodes
{
    public class CreateEpisodeValidator : AbstractValidator<ICreateEpisodeModel>, ICreateEpisodeValidator
    {
        private readonly IEpisodeRepository _episodeRepository;

        public CreateEpisodeValidator(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;

            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(64);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ICreateEpisodeModel> context, CancellationToken cancellation = default)
        {
            await ValidateEpisodeAlreadyExists(context);

            return await base.ValidateAsync(context, cancellation);
        }

        private async Task ValidateEpisodeAlreadyExists(ValidationContext<ICreateEpisodeModel> context)
        {
            Episode episode = await _episodeRepository.GetByOrDefaultAsync(x => x.Name == context.InstanceToValidate.Name);

            if (episode != null) throw new EntityAlreadyExistException(context.InstanceToValidate.Name);
        }
    }
}