using AutoMapper;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class SearchService : ISearchService {
        private readonly IMapper _mapper;

        public SearchService(IMapper mapper) {
            this._mapper = mapper;
        }
    }
}
