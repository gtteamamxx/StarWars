using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException(int id) : base($"Entity {typeof(T).Name} with id: {id} not found")
        {
        }
    }
}