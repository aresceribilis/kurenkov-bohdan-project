using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class PostPreviewMap : Profile
    {
        public PostPreviewMap()
        {
            CreateMap<Post, PostPreviewDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(@do => @do.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(@do => @do.UserPostsCount,
                    opt => opt.MapFrom(dto => dto.UserPosts.Count));
        }
    }
}