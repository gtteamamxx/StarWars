using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CannotCreateCharacterWithNotExistedCharacterException : Exception
    {
        public CannotCreateCharacterWithNotExistedCharacterException(string notExistedFriendName)
           : base($"Cannot create character and assing it into friend when character {notExistedFriendName} does not exist." +
                 $" Create character first.")
        {
        }
    }
}