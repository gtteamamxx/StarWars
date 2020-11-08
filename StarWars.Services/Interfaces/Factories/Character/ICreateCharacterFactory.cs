using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Interfaces.Factories.Character
{
    public interface ICreateCharacterFactory
    {
        DataAccess.Model.Character Create(ICreateCharacterModel createModel);
    }
}