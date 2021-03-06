﻿using Microsoft.EntityFrameworkCore;
using StarWars.Common.Concrete;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Interfaces;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.DataAccess.Infrastructure.Repositories
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(IDatabaseContext context) : base(context)
        {
        }

        public override Expression<Func<Character, int>> GetKeyExpression() => x => x.Id;
    }
}