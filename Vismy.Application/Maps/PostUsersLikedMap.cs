using System.Linq;
using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class PostUsersLikedMap : Profile
    {
        public PostUsersLikedMap()
        {
            CreateMap<Post, PostUsersLikedDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Likers,
                    opt => opt.MapFrom(dto => dto.UserPosts
                        .Where(p => p.UserPostStatus.Name == "Liked")
                        .Select(pu => pu.User)))
                .ReverseMap();
        }
    }
}