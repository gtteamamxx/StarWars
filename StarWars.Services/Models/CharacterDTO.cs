using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWars.Services.Models
{
    public class CharacterDTO
    {
        public List<string> Episodes { get; set; } = new List<string>();

        public List<string> Friends { get; set; } = new List<string>();

        public string Name { get; set; } = default!;
    }
}