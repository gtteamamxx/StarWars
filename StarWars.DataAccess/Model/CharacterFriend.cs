using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StarWars.DataAccess.Model
{
    public class CharacterFriend
    {
        [ForeignKey(nameof(CharacterId))]
        public virtual Character Character { get; set; } = default!;

        [Required]
        public int CharacterId { get; set; }

        [ForeignKey(nameof(FriendCharacterId))]
        public virtual Character Friend { get; set; } = default!;

        [Required]
        public int FriendCharacterId { get; set; }

        [Key]
        public int Id { get; set; }
    }
}