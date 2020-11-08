using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using StarWars.API.Models;
using StarWars.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.API.IntegrationTests
{
    [TestFixture]
    public class CharactersControllerTests : TestBase
    {
        [Test]
        public async Task Adding_New_Character_With_Friends_Should_Add_Character_And_Assing_Friends()
        {
            // Arrange
            _database.Set<Character>().Add(new Character() { Name = "friend1" });
            _database.Set<Character>().Add(new Character() { Name = "friend2" });

            var createModel = new CreateCharacterModel()
            {
                Friends = new List<string>()
                {
                    "friend1", "friend2"
                },
                Name = "sampleCharacter"
            };

            // Act
            int createdCharacterId = (int)(await _charactersController.AddNewCharacter(createModel) as CreatedResult).Value;

            // Assert
            createdCharacterId.Should().BeGreaterThan(0);

            List<CharacterFriend> friendAssignments = _database.Set<CharacterFriend>()
                .Where(x => x.CharacterId == createdCharacterId)
                .ToList();

            friendAssignments.Should().HaveCount(createModel.Friends.Count);

            foreach (CharacterFriend friendAssignment in friendAssignments)
            {
                createModel.Friends.Should().Contain(friendAssignment.Friend.Name);
            }
        }
    }
}