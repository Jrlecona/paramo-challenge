using AutoMapper;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.MappingProfiles;

public class ResultMappingProfile : Profile
{
    public ResultMappingProfile()
    {
        CreateMap<Result, ResultDto>().ReverseMap();
    }
}