using Moq;
using NUnit.Framework;
using StarWars.DataAccess.Model;
using StarWars.Services.Exceptions;
using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Tests.Validators
{
    [TestFixture]
    public partial class CreateEpisodeValidatorTests
    {
        [Test]
        public void ValidateAsync_Should_Throw_Exception_When_Episode_Already_Exist_With_Same_Name()
        {
            // Arrange
            string episodeName = "test";

            ICreateEpisodeModel createEpisodeModel = CreateEpisodeModel(episodeName);

            _episodeRepositoryMock.Setup(x => x.GetByOrDefaultAsync(It.IsAny<Expression<Func<Episode, bool>>>()))
                .Returns(Task.FromResult(new Episode() { Name = episodeName }));

            // Assert
            Assert.ThrowsAsync<EntityAlreadyExistException>(async () =>
            {
                // Act
                await _validator.ValidateAsync(createEpisodeModel);
            });
        }
    }
}