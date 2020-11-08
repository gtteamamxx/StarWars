using StarWars.Common.Concrete;
using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StarWars.Common.Tests.Concrete
{
    public class TestRepository : RepositoryBase<TestModel>
    {
        public TestRepository(IDatabaseContext context) : base(context)
        {
        }

        public override Expression<Func<TestModel, int>> GetKeyExpression() => x => x.Key;
    }
}