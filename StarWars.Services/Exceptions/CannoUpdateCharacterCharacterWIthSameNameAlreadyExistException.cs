using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class CannoUpdateCharacterCharacterWIthSameNameAlreadyExistException : Exception
    {
        public CannoUpdateCharacterCharacterWIthSameNameAlreadyExistException(int id, string newName)
            : base($"Cannot update character with id: {id} because character with same name: '{newName}' already exist")
        {
        }
    }
}