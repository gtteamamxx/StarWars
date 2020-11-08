using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Interfaces.Factories.Episodes
{
    public interface ICreateEpisodeFactory
    {
        Episode Create(ICreateEpisodeModel createModel);
    }
}