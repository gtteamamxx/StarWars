using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Models
{
    public class EpisodeDTO
    {
        public List<string> Characters { get; set; } = new List<string>();

        public string Name { get; set; } = default!;
    }
}