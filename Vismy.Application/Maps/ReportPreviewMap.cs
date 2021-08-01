using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class ReportPreviewMap : Profile
    {
        public ReportPreviewMap()
        {
            CreateMap<Report, ReportPreviewDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ReverseMap();
        }
    }
}