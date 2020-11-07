using AutoMapper;
using StarWars.DataAccess.Model;
using StarWars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Services.Mapper
{
    public class StarWarsServiceMapperProfile : Profile
    {
        public StarWarsServiceMapperProfile() : base(nameof(StarWarsServiceMapperProfile), x =>
        {
            x.CreateMap<Character, CharacterDTO>();
        })
        {
        }
    }
}