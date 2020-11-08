using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException(string name) : base($"Entity with name '{name}' already exists.")
        {
        }
    }
}