using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class UserPreviewMap : Profile
    {
        public UserPreviewMap()
        {
            CreateMap<AspNetUser, UserPreviewDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(@do => @do.Surname,
                    opt => opt.MapFrom(dto => dto.Surname))
                .ForMember(@do => @do.IconPath,
                    opt => opt.MapFrom(dto => dto.IconPath))
                .ForMember(@do => @do.Nickname,
                    opt => opt.MapFrom(dto => dto.UserName))
                .ReverseMap();
        }
    }
}