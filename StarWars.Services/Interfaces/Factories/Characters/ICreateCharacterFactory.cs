using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Interfaces.Factories.Characters
{
    public interface ICreateCharacterFactory
    {
        Character Create(ICreateCharacterModel createModel);
    }
}