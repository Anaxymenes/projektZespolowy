using AutoMapper;
using Data.Add;
using Data.DBModel;
using Data.DTO;
using Data.Edit;
using Data.EditViewModel;
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

            CreateMap<CommentEditV2, Comment>()
               .BeforeMap((src, dest) => dest.Date = DateTime.Now)
               .ForMember(dest => dest.Content,
               opt => opt.MapFrom(src => src.content))
               .ForMember(dest => dest.PostId,
               opt => opt.MapFrom(src => src.Id))
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

            CreateMap<HobbyAdd, Hobby>()
               .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Logo,
                opt => opt.MapFrom(src => src.Logo))
                .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color))
                ;

            CreateMap<Hobby, HobbyForPostDTO>()
               .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color))
                ;

            CreateMap<HobbyEdit, Hobby>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AdministratorId,
                opt => opt.MapFrom(src => src.accountId))
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.color))
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

            CreateMap<PostDTO, Post>()
                .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.AuthorId,
                opt => opt.MapFrom(src => src.AuthorId))
                ;

            CreateMap<PostAdd, PostDTO>()
                .BeforeMap((src, dest) => dest.Date = DateTime.Now)
                .ForMember(dest => dest.Content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Hobbys,
                opt => opt.MapFrom(src => src.Hobbys))
                .ForMember(dest => dest.Event,
                opt => opt.MapFrom(src => src.Event))
                ;

            CreateMap<RegisterAccountDTO, Account>()
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.AccountDetails,
                opt => opt.MapFrom(src => new AccountDetails {
                    BirthDate = src.BirthDate,
                    Name = src.FirstName,
                    LastName = src.LastName
                }))
                ;

            CreateMap<CommentAdd, Comment>()
                .BeforeMap((src, dest) => dest.Date = DateTime.Now)
                .ForMember(dest => dest.Content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.PostId,
                opt => opt.MapFrom(src => src.PostId))
                ;
        }
    }
}
