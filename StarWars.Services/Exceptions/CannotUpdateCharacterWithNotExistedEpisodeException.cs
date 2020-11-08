using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CannotUpdateCharacterWithNotExistedEpisodeException : Exception
    {
        public CannotUpdateCharacterWithNotExistedEpisodeException(string notExistingEpisodeName)
           : base($"Cannot update character and assing it into episode when episode {notExistingEpisodeName} does not exist." +
                 $" Create episode first.")
        {
        }
    }
}