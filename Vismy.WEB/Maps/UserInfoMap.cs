using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class UserInfoMap : Profile
    {
        public UserInfoMap()
        {
            CreateMap<IdentityRole, UserInfoDTO>()
                .ForMember(@do => @do.RoleName,
                    opt => opt.MapFrom(dto => dto.Name))
                .ReverseMap();

            CreateMap<AspNetUser, UserInfoDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(@do => @do.Surname,
                    opt => opt.MapFrom(dto => dto.Surname))
                .ForMember(@do => @do.BirthDate,
                    opt => opt.MapFrom(dto => dto.BirthDate))
                .ForMember(@do => @do.IconPath,
                    opt => opt.MapFrom(dto => dto.IconPath))
                .ForMember(@do => @do.Nickname,
                    opt => opt.MapFrom(dto => dto.UserName))
                .ForMember(@do => @do.Email,
                    opt => opt.MapFrom(dto => dto.Email))
                .ForMember(@do => @do.EmailConfirmed,
                    opt => opt.MapFrom(dto => dto.EmailConfirmed))
                .ForMember(@do => @do.PhoneNumber,
                    opt => opt.MapFrom(dto => dto.PhoneNumber))
                .ForMember(@do => @do.PhoneNumberConfirmed,
                    opt => opt.MapFrom(dto => dto.PhoneNumberConfirmed))
                .ForMember(@do => @do.Password, 
                    opt => opt.MapFrom(dto => dto.PasswordHash))
                .ReverseMap();
        }
    }
}