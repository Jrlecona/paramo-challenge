using AutoMapper;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Domain.Entities;
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

    public async Task<ResultDto> ValidateUser(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        var validateResult = await _userRepository.ValidateUser(userEntity);
        var result = _mapper.Map<ResultDto>(validateResult);

        return result;
    }

    public async Task<ResultDto> CreateUser(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        var entityResult = await _userRepository.CreateUser(userEntity);
        var result = _mapper.Map<ResultDto>(entityResult);

        return result;
    }
}