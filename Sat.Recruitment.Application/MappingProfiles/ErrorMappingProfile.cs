using AutoMapper;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.MappingProfiles;

public class ErrorMappingProfile : Profile
{
    public ErrorMappingProfile()
    {
        CreateMap<ErrorDto, Error>().ReverseMap();
    }
}