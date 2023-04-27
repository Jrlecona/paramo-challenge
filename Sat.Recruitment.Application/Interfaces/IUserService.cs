using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result> CreateUser(UserDto userDto);
        Task<Result> ValidateUser(UserDto userDto);
    }
}
