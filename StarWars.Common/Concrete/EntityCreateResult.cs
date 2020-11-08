using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Common.Concrete
{
    public class EntityCreateResult<T> : IEntityCreateResult
    {
        private readonly T _entity;
        private readonly Func<T, int> _keyExpr;

        public EntityCreateResult(T entity, Func<T, int> keyExpr)
        {
            _entity = entity;
            _keyExpr = keyExpr;
        }

        public int GetId() => _keyExpr.Invoke(_entity);
    }
}