using Moq;
using NUnit.Framework;
using StarWars.DataAccess.Interfaces;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Validators.Episodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Tests.Validators
{
    [TestFixture]
    public partial class CreateEpisodeValidatorTests
    {
        private Mock<IEpisodeRepository> _episodeRepositoryMock;

        private CreateEpisodeValidator _validator => new CreateEpisodeValidator(
            _episodeRepositoryMock.Object
        );

        [SetUp]
        public void BeforeEachTest()
        {
            _episodeRepositoryMock = new Mock<IEpisodeRepository>();
        }

        private ICreateEpisodeModel CreateEpisodeModel(string name)
        {
            var mock = new Mock<ICreateEpisodeModel>();

            mock.SetupGet(x => x.Name).Returns(name);

            return mock.Object;
        }
    }
}