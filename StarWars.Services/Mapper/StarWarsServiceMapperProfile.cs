﻿using AutoMapper;
using StarWars.DataAccess.Model;
using StarWars.Services.Interfaces.Models;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWars.Services.Mapper
{
    public class StarWarsServiceMapperProfile : Profile
    {
        public StarWarsServiceMapperProfile() : base(nameof(StarWarsServiceMapperProfile), x =>
        {
            x.CreateMap<Character, CharacterDTO>()
                .ForMember(x => x.Episodes, x => x.MapFrom(y => y.Episodes.Select(y => y.Episode)));
            x.CreateMap<Episode, EpisodeDTO>();
        })
        {
        }
    }
}