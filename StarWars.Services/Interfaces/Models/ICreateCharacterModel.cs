using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Interfaces.Models
{
    public interface ICreateCharacterModel
    {
        List<string> Episodes { get; }

        List<string> Friends { get; }

        string Name { get; }
    }
}