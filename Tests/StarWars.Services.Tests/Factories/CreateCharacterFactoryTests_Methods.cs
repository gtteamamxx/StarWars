using Moq;
using NUnit.Framework;
using StarWars.DataAccess.Interfaces;
using StarWars.Services.Factories.Characters;
using StarWars.Services.Interfaces.Factories.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Tests.Factories
{
    public partial class CreateCharacterFactoryTests
    {
        private Mock<ICharacterRepository> _characterRepositoryMock;
        private Mock<IEpisodeRepository> _episodeRepositoryMock;

        private CreateCharacterFactory _factory => new CreateCharacterFactory(
            _episodeRepositoryMock.Object,
            _characterRepositoryMock.Object
        );

        [SetUp]
        public void BeforeEachTest()
        {
            _characterRepositoryMock = new Mock<ICharacterRepository>();
            _episodeRepositoryMock = new Mock<IEpisodeRepository>();
        }
    }
}