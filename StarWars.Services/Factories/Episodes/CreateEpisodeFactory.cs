using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Factories.Episodes;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Factories.Episodes
{
    public class CreateEpisodeFactory : ICreateEpisodeFactory
    {
        public Episode Create(ICreateEpisodeModel createModel)
        {
            return new Episode()
            {
                Name = createModel.Name
            };
        }
    }
}