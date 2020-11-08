using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Factories.Characters;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Factories.Characters
{
    public class CreateCharacterFactory : ICreateCharacterFactory
    {
        public Character Create(ICreateCharacterModel createModel)
        {
            return new Character()
            {
                Name = createModel.Name
            };
        }
    }
}