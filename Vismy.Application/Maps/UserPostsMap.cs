using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class UserPostsMap : Profile
    {
        public UserPostsMap()
        {
            CreateMap<AspNetUser, UserPostsDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Posts,
                    opt => opt.MapFrom(dto => dto.Posts))
                .ReverseMap();
        }
    }
}