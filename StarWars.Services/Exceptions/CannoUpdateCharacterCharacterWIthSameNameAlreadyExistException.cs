using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CannoUpdateCharacterCharacterWithSameNameAlreadyExistException : Exception
    {
        public CannoUpdateCharacterCharacterWithSameNameAlreadyExistException(int id, string newName)
            : base($"Cannot update character with id: {id} because character with same name: '{newName}' already exist")
        {
        }
    }
}