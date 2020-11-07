using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StarWars.DataAccess.Model
{
    public class Character
    {
        public virtual ICollection<CharacterEpisode> Episodes { get; set; } = new HashSet<CharacterEpisode>();

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}