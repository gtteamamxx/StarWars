using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CharacterCannotBeFriendWithSelfException : Exception
    {
        public CharacterCannotBeFriendWithSelfException()
            : base("Character cannot be friend with self.")
        {
        }
    }
}