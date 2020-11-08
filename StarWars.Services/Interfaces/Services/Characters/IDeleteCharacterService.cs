using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Characters
{
    public interface IDeleteCharacterService
    {
        Task DeleteAsync(int id);
    }
}