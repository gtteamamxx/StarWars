using FluentAssertions;
using Moq;
using NUnit.Framework;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Tests.Factories
{
    [TestFixture]
    public partial class CreateCharacterFactoryTests
    {
        [Test]
        public async Task CreateAsync_Should_Create_Character_With_Assigned_Friends_Got_From_Database_By_Update_Model()
        {
            // Arrange
            ICreateCharacterModel createModel = new Mock<ICreateCharacterModel>().Object;

            var expectedFriendIds = new List<int>() { 5, 9 };

            _episodeRepositoryMock.Setup(x => x.GetAllByOrDefaultAsync(It.IsAny<Expression<Func<Episode, bool>>>()))
                .Returns(Task.FromResult(new List<Episode>()));

            _characterRepositoryMock.Setup(x => x.GetAllByOrDefaultAsync(It.IsAny<Expression<Func<Character, bool>>>()))
                .Returns(Task.FromResult(expectedFriendIds.Select(x => new Character() { Id = x }).ToList()));

            // Act
            Character createdCharacter = await _factory.CreateAsync(createModel);

            // Assert
            createdCharacter.Friends.Should().HaveCount(expectedFriendIds.Count);

            foreach (int expectedFriendId in expectedFriendIds)
            {
                createdCharacter.Friends.Should().Contain(x => x.FriendCharacterId == expectedFriendId);
            }
        }
    }
}