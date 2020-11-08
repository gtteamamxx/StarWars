using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.API.Models
{
    public class UpdateCharacterModel : IUpdateCharacterModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
    }
}