using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Interfaces.Models
{
    public interface ICreateCharacterModel
    {
        List<string> Episodes { get; }

        string Name { get; }
    }
}