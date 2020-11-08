using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Models
{
    public class EpisodeDTO
    {
        public List<CharacterDTO> Characters { get; set; } = new List<CharacterDTO>();

        public string Name { get; set; } = default!;
    }
}