using AutoMapper;
using Data.Search;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class SearchService : ISearchService {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IHobbyService _hobbyService;

        public SearchService(IMapper mapper,
                             IAuthService authService,
                             IHobbyService hobbyService) {
            this._mapper = mapper;
            this._authService = authService;
            this._hobbyService = hobbyService;
        }

        public SearchDTO FindIntoDb(string value) {
            SearchDTO result = new SearchDTO();
            result.AccountResults = _authService.FindAccountsByValue(value);
            result.HobbyResults = _hobbyService.FindHobbyByValue(value);
            return result;
        }
    }
}
