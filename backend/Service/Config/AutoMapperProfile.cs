using AutoMapper;
using Data.DBModel;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Config
{
    public class AutoMapperProfile : Profile
    {
        private readonly IMapper _mapper;
        private EventDTO eventDTO;

        public AutoMapperProfile(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AutoMapperProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.AccountDetails.Name))
                .ForMember(dest => dest.Avatar,
                opt => opt.MapFrom(src => src.AccountDetails.Avatar))
                .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.AccountDetails.Name))
                .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.AccountDetails.LastName))
                .ForMember(dest => dest.Role,
                opt => opt.MapFrom(src => src.AccountRole.Name))
                ;
            CreateMap<Comment, CommentDTO>()
               .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.AuthorId,
                opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.PostId,
                opt => opt.MapFrom(src => src.PostId))
                ;
            CreateMap<EventDetails, EventDTO>()
               .ForMember(dest => dest.StartAt,
                opt => opt.MapFrom(src => src.StartAt))
                .ForMember(dest => dest.EndAt,
                opt => opt.MapFrom(src => src.EndAt))
                .ForMember(dest => dest.Longitude,
                opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude,
                opt => opt.MapFrom(src => src.Latitude))
                ;
            CreateMap<Hobby, HobbyDTO>()
               .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Logo,
                opt => opt.MapFrom(src => src.Logo))
                .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.AdministratorId,
                opt => opt.MapFrom(src => src.AdministratorId))
                ;
            CreateMap<Hobby, HobbyForPostDTO>()
               .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color))
                ;

            CreateMap<Post, PostDTO>()
                .BeforeMap((src, dest) => eventDTO = _mapper.Map<EventDTO>(src.EventDetalis))
               .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => src.Author.AccountDetails.Name + " " + src.Author.AccountDetails.LastName))
                .ForMember(dest => dest.AuthorId,
                opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Event,
                opt => opt.UseValue(eventDTO))
                .ForMember(dest => dest.Pictures,
                opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    if (src.Pictures != null && src.Pictures.Count > 0)
                    {
                        List<string> pct = new List<string>();
                        foreach (var obj in src.Pictures)
                            pct.Add(obj.Path);
                        dest.Pictures = pct;
                    }
                })
                ;
            CreateMap<RegisterAccountDTO, Account>()
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.AccountDetails.Name,
                opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.AccountDetails.LastName,
                opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.AccountDetails.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate))
                ;
        }
    }
}
