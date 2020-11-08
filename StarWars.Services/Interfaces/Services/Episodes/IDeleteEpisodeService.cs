using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services.Interfaces.Services.Episodes
{
    public interface IDeleteEpisodeService
    {
        Task DeleteAsync(int id);
    }
}