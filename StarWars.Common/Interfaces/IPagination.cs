using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Common.Interfaces
{
    public interface IPagination
    {
        int ElementIndex { get; }

        int PageSize { get; }
    }
}