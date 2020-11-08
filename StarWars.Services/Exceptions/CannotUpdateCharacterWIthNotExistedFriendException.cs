using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CannotUpdateCharacterWithNotExistedFriendException : Exception
    {
        public CannotUpdateCharacterWithNotExistedFriendException(string newName)
            : base($"Cannot update character and assing it into friend when friend {newName} does not exist." +
                 $" Create character first.")
        {
        }
    }
}