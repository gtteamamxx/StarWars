using StarWars.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.API.Models
{
    public class PaginationModel : IPagination
    {
        public PaginationModel(int elementIndex, int pageSize)
        {
            ElementIndex = elementIndex;
            PageSize = pageSize;
        }

        public int ElementIndex { get; set; }

        public int PageSize { get; set; }
    }
}