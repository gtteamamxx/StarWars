using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CharacterCannotBeCreatedWithNotExistedEpisodeException : Exception
    {
        public CharacterCannotBeCreatedWithNotExistedEpisodeException(string notExistingEpisodeName)
            : base($"Cannot create character and assing it into episode when episode {notExistingEpisodeName} does not exist." +
                  $" Create episode first.")
        {
        }
    }
}