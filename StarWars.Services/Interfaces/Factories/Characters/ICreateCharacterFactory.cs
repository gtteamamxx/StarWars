using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Factories.Characters
{
    public interface ICreateCharacterFactory
    {
        Task<Character> CreateAsync(ICreateCharacterModel createModel);
    }
}