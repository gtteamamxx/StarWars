using Moq;
using NUnit.Framework;
using StarWars.Common.Concrete;
using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Common.Tests.Concrete
{
    [TestFixture]
    public partial class RepositoryBaseTests
    {
        private Mock<IDatabaseContext> _databaseContextMock;
        private TestRepository _repository;

        [SetUp]
        public void BeforeEachTest()
        {
            _databaseContextMock = new Mock<IDatabaseContext>();

            var repositoryMock = new Mock<TestRepository>(() =>
                new TestRepository(_databaseContextMock.Object)
            );

            repositoryMock.CallBase = true;

            _repository = repositoryMock.Object;
        }
    }
}