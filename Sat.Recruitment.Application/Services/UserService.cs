using AutoMapper;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;

namespace Sat.Recruitment.Application.Services;

public class UserService : IUserService
{
    private readonly AppSettings _appSettings;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IOptions<AppSettings> appSettings, IMapper mapper, IUserRepository userRepository)
    {
        _appSettings = appSettings.Value;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<Result> CreateUser(UserDto userDto)
    {
        var result = new Result
        {
            IsSuccess = true,
            MessagesErrors = new List<Error>()
        };

        //if (userDto.Name == null)
        //{
        //    result.MessagesErrors.Add(new Error(ErrorTypes.Name, _appSettings.NameError));
        //    result.IsSuccess = false;
        //}

        //if (userDto.Email == null)
        //{
        //    result.MessagesErrors.Add(new Error(ErrorTypes.Name, _appSettings.EmailError));
        //    result.IsSuccess = false;
        //}

        //if (userDto.Address == null)
        //{
        //    result.MessagesErrors.Add(new Error(ErrorTypes.Name, _appSettings.AddressError));
        //    result.IsSuccess = false;
        //}

        //if (userDto.Phone == null)
        //{
        //    result.MessagesErrors.Add(new Error(ErrorTypes.Name, _appSettings.PhoneError));
        //    result.IsSuccess = false;
        //}

        //result.IsSuccess = StringUtils.IsValidEmail(userDto.Email);
        //if (!result.IsSuccess) result.MessagesErrors.Add(new Error(ErrorTypes.Email, _appSettings.EmailFormatError));

        //if (!result.IsSuccess) return result;

        var userEntity = _mapper.Map<User>(userDto);
        var entityResult = await _userRepository.CreateUser(userEntity);
        result = _mapper.Map<Result>(entityResult);


        return result;
    }
}