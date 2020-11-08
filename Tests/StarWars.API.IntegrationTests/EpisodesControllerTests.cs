using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using StarWars.API.Controllers;
using StarWars.API.Models;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.API.IntegrationTests
{
    [TestFixture]
    public class EpisodesControllerTests : TestBase
    {
        [Test]
        public async Task Add_Valid_Episode_Should_Add_It_To_Database()
        {
            // Arrange
            var createModel = new CreateEpisodeModel() { Name = "test" };

            // Act
            await _episodesController.AddNewEpisode(createModel);

            // Assert
            Episode addedEpisode = _database.Set<Episode>().FirstOrDefault(x => x.Name == createModel.Name);

            addedEpisode.Should().NotBeNull();

            addedEpisode.Name.Should().Be(createModel.Name);
        }
    }
}