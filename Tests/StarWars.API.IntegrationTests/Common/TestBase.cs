using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Scrutor;
using StarWars.API.Controllers;
using StarWars.API.IntegrationTests.Common;
using StarWars.Common.Interfaces;
using StarWars.DataAccess.Infrastructure;
using StarWars.DataAccess.Interfaces;
using StarWars.Services.Interfaces.Services.Characters;
using StarWars.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.API.IntegrationTests
{
    public abstract class TestBase
    {
        protected IServiceProvider _serviceProvider;

        protected CharactersController _charactersController => _serviceProvider.GetService<CharactersController>();

        protected IDatabaseContext _database => _serviceProvider.GetService<IDatabaseContext>();

        protected EpisodesController _episodesController => _serviceProvider.GetService<EpisodesController>();

        [OneTimeSetUp]
        public void Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<EpisodesController>();
            services.AddScoped<CharactersController>();

            services.AddScoped<IDatabaseContext, StarWarsContext>(
                x => new StarWarsMemoryContext(new DbContextOptionsBuilder<StarWarsContext>()
                    .UseInMemoryDatabase(nameof(StarWarsContext))
                    .EnableSensitiveDataLogging()
                    .Options
            ));

            services.AddSingleton<IMapper>(y =>
            {
                var mapper = new MapperConfiguration(x =>
                {
                    x.AddProfile<StarWarsServiceMapperProfile>();
                });

                return mapper.CreateMapper();
            });

            services.Scan(scan =>
                scan.FromAssemblyOf<ICharactersService>()
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime()
            );

            services.Scan(scan =>
                scan.FromAssemblyOf<ICharacterRepository>()
                    .AddClasses()
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}