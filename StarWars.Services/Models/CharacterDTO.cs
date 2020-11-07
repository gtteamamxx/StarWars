﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Models
{
    public class CharacterDTO
    {
        public List<EpisodeDTO> Episodes = new List<EpisodeDTO>();

        public string Name { get; set; } = default!;
    }
}