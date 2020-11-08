using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CannotUpdateEpisodeEpisodeWithSameNameAlreadyExistException : Exception
    {
        public CannotUpdateEpisodeEpisodeWithSameNameAlreadyExistException(int id, string newName)
            : base($"Cannot update episode with id: {id} because episode with same name: '{newName}' already exist")
        {
        }
    }
}