using System.Linq;
using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class UserFollowingMap : Profile
    {
        public UserFollowingMap()
        {
            CreateMap<AspNetUser, UserFollowingDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Following,
                    opt => opt.MapFrom(dto => dto.UserUserUsers
                        .Select(uu => uu.User)))
                .ReverseMap();
        }
    }
}