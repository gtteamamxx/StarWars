using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Interfaces.Models
{
    public interface IUpdateCharacterModel
    {
        List<string> Episodes { get; }

        int Id { get; }

        string Name { get; }
    }
}