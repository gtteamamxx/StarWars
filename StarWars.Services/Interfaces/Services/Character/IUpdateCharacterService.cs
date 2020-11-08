﻿using StarWars.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Character
{
    public interface IUpdateCharacterService
    {
        Task UpdateCharacterAsync(IUpdateCharacterModel updateModel);
    }
}