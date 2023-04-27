using System.ComponentModel;
using AutoMapper;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;

namespace Sat.Recruitment.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<Result> ValidateUser(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        var entityResult = _userRepository.ValidateUser(userEntity);
        var result = _mapper.Map<Result>(entityResult.Result);

        return result;
    }

    public async Task<Result> CreateUser(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        var entityResult = await _userRepository.CreateUser(userEntity);
        var result = _mapper.Map<Result>(entityResult);

        return result;
    }
}