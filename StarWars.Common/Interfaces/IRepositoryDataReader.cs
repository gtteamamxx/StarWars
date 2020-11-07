using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Common.Interfaces
{
    public interface IRepositoryDataReader<T>
    {
        Task<List<T>> GetAllAsync();
    }
}