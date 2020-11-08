using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Common.Tests.Concrete
{
    [TestFixture]
    public partial class RepositoryBaseTests
    {
        [Test]
        public void Add_Should_Add_Element_To_Context()
        {
            // Arrange
            var expectedElementToAdd = new TestModel();

            var dbSetMock = new Mock<DbSet<TestModel>>();

            TestModel addedElement = null;
            dbSetMock.Setup(x => x.Add(It.IsAny<TestModel>()))
                .Callback<TestModel>(passedElement => addedElement = passedElement);

            _databaseContextMock.Setup(x => x.Set<TestModel>())
                .Returns(dbSetMock.Object);

            // Assert
            _repository.Add(expectedElementToAdd);

            // Assert
            addedElement.Should().Be(expectedElementToAdd);
        }

        [Test]
        public void Add_Should_Return_Entity_Create_Result_Wih_Pointer_To_Key()
        {
            // Arrange
            int expectedId = 5;

            var element = new TestModel() { Key = expectedId };

            _databaseContextMock.Setup(x => x.Set<TestModel>())
                .Returns(new Mock<DbSet<TestModel>>().Object);

            // Assert
            IEntityCreateResult result = _repository.Add(element);

            // Assert
            result.GetId().Should().Be(expectedId);
        }
    }
}