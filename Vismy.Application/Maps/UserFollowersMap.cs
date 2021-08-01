using System.Linq;
using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class UserFollowersMap : Profile
    {
        public UserFollowersMap()
        {
            CreateMap<AspNetUser, UserFollowersDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Followers,
                    opt => opt.MapFrom(dto => dto.UserUserFollowers
                        .Select(uu => uu.Follower)))
                .ReverseMap();
        }
    }
}