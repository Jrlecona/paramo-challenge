﻿using AutoMapper;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
    }
}