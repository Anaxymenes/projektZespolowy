using AutoMapper;
using Data.DBModels;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Post, PostDTO>();
            CreateMap<Hobby, HobbyDTO>();
        }
    }
}
