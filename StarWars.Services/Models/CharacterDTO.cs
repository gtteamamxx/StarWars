using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWars.Services.Models
{
    public class CharacterDTO
    {
        public List<EpisodeDTO> Episodes { get; set; } = new List<EpisodeDTO>();

        public List<FriendDTO> Friends { get; set; } = new List<FriendDTO>();

        public string Name { get; set; } = default!;
    }
}