using AutoMapper;
using Sat.Recruitment.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
