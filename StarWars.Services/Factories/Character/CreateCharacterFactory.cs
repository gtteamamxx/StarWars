using StarWars.Services.Interfaces.Factories.Character;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Factories.Character
{
    public class CreateCharacterFactory : ICreateCharacterFactory
    {
        public DataAccess.Model.Character Create(ICreateCharacterModel createModel)
        {
            return new DataAccess.Model.Character()
            {
                Name = createModel.Name
            };
        }
    }
}