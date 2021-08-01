using System.Linq;
using AutoMapper;
using Vismy.Application.DTOs;
using Vismy.Core.Models.Implementations;

namespace Vismy.Application.Maps
{
    public class ReportInfoMap : Profile
    {
        public ReportInfoMap()
        {
            CreateMap<Report, ReportInfoDTO>()
                .ForMember(@do => @do.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(@do => @do.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(@do => @do.Score,
                    opt => opt.MapFrom(dto => dto.UserReportAuthors
                        .Count))
                .ForMember(@do => @do.ScoreApproved,
                    opt => opt.MapFrom(dto => dto.UserReportModerators
                        .Count(r => r.UserReportModeratorStatus.Name == "Approved")))
                .ForMember(@do => @do.ScoreDisapproved,
                    opt => opt.MapFrom(dto => dto.UserReportModerators
                        .Count(r => r.UserReportModeratorStatus.Name == "Disapproved")))
                .ForMember(@do => @do.Post,
                    opt => opt.MapFrom(dto => dto.Post))
                .ForMember(@do => @do.TypeName,
                    opt => opt.MapFrom(dto => dto.ReportStatus.Name))
                .ForMember(@do => @do.TypeDescription,
                    opt => opt.MapFrom(dto => dto.ReportStatus.Description))
                .ReverseMap();
        }
    }
}