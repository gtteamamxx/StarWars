using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StarWars.Common.Tests
{
    public class TestModel
    {
        public static Expression<Func<TestModel, int>> KeyExpression = x => x.Key;

        public static Expression<Func<TestModel, object>> ListObjectExpression => x => x.Elements.Select(x => x.Object);

        public List<TestModel> Elements { get; set; }

        public int Key { get; set; }

        public int Object { get; set; }
    }
}