using Data.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ISearchService {
        SearchDTO FindIntoDb(string value);
    }
}
