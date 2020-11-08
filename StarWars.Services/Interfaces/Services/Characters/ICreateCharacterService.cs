using StarWars.Common.Interfaces;
using StarWars.Services.Interfaces.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Characters
{
    public interface ICreateCharacterService
    {
        Task<IEntityCreateResult> CreateCharacterAsync(ICreateCharacterModel createCharacterModel);
    }
}