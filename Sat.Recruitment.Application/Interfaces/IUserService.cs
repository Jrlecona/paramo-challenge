using Sat.Recruitment.Application.Dtos;

namespace Sat.Recruitment.Application.Interfaces;

public interface IUserService
{
    Task<ResultDto> CreateUser(UserDto userDto);
    Task<ResultDto> ValidateUser(UserDto userDto);
}