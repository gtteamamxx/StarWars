using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StarWars.DataAccess.Model
{
    public class CharacterEpisode
    {
        [ForeignKey(nameof(CharacterId))]
        public virtual Character Character { get; set; }

        public int CharacterId { get; set; }

        [ForeignKey(nameof(EpisodeId))]
        public virtual Episode Episode { get; set; }

        public int EpisodeId { get; set; }

        [Key]
        public int Id { get; set; }
    }
}