using System.Linq;
using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class PostInfoMap : Profile
    {
        public PostInfoMap()
        {
            CreateMap<Post, PostInfoDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Shared,
                    opt => opt.MapFrom(dto => dto.Shared))
                .ForMember(@do => @do.Viewed,
                    opt => opt.MapFrom(dto => dto.UserPosts
                        .Count))
                .ForMember(@do => @do.Liked,
                    opt => opt.MapFrom(dto => dto.UserPosts
                        .Count(up => up.UserPostStatus.Name == "Liked")))
                .ForMember(@do => @do.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                //.ForMember(@do => @do.StatusName,
                //    opt => opt.MapFrom(dto => dto.PostStatus.Name))
                //.ForMember(@do => @do.StatusDescription,
                //    opt => opt.MapFrom(dto => dto.PostStatus.Description))
                //.ForMember(@do => @do.AuthorNickname,
                //    opt => opt.MapFrom(dto => dto.User.UserName))
                .ForMember(@do => @do.Tags,
                    opt => opt.MapFrom(dto => dto.PostTags
                        .Select(pt => pt.Tag.Name)));

            CreateMap<PostInfoDTO, Post>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Shared,
                    opt => opt.MapFrom(dto => dto.Shared))
                .ForMember(@do => @do.Description,
                    opt => opt.MapFrom(dto => dto.Description));
        }
    }
}