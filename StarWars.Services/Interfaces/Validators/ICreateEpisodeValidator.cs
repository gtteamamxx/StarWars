using FluentValidation;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Interfaces.Validators
{
    public interface ICreateEpisodeValidator : IValidator<ICreateEpisodeModel>
    {
    }
}