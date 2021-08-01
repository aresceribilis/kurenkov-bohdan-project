using System.Linq;
using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class PostUsersViewedMap : Profile
    {
        public PostUsersViewedMap()
        {
            CreateMap<Post, PostUsersViewedDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Viewers,
                    opt => opt.MapFrom(dto => dto.UserPosts
                        .Where(p => p.UserPostStatus.Name == "Viewed")
                        .Select(pu => pu.User)))
                .ReverseMap();
        }
    }
}