using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infrastructure.Repositories;
using Xunit;

namespace Sat.Recruitment.Test;

public class UsersControllerTests : IDisposable
{
    private readonly UsersController _usersController;

    public UsersControllerTests()
    {
        var appSettings = Options.Create(new AppSettings("The name is required", "The email is required",
            "The address is required", "The phone is required", "User Created", "User Duplicated",
            "/Resources/Users.txt", "The email format is incorrect"));
        var userRepository = new UserRepository(appSettings);
        var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutoMapperProfile()));
        var mapper = new Mapper(mapperConfig);
        IUserService userService = new UserService(mapper, userRepository);

        _usersController = new UsersController(userService);
    }

    public void Dispose()
    {
        // Clean up any resources used by the test
    }

    [Fact]
    public async Task CreateUser_Success()
    {
        // Act
        var result = await _usersController.CreateUser(
            "Mike",
            "mike@gmail.com",
            "Av. Juan G",
            "+349 1122354215",
            "Normal",
            "124");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var resultDtoValue = Assert.IsType<ResultDto>(okResult.Value);

        Assert.True(resultDtoValue.IsSuccess);
        Assert.Empty(resultDtoValue.Errors);
    }

    [Fact]
    public async Task CreateUser_Duplicate()
    {
        // Act
        var result = await _usersController.CreateUser(
            "Agustina",
            "Agustina@gmail.com",
            "Av. Juan G",
            "+349 1122354215",
            "Normal",
            "124");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var resultDtoValue = Assert.IsType<ResultDto>(okResult.Value);

        Assert.False(resultDtoValue.IsSuccess);
        Assert.Contains(resultDtoValue.Errors, error => error.Message == "User Duplicated");
    }

    private class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<ResultDto, Result>().ReverseMap();
            CreateMap<ErrorDto, Error>().ReverseMap();
        }
    }
}