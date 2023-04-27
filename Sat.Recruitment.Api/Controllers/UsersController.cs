using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Dtos;
using Sat.Recruitment.Application.Interfaces;

namespace Sat.Recruitment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("/create-user")]
    public async Task<IActionResult> CreateUser(string name, string email, string address, string phone,
        string userType, string money)
    {
        var userDto = new UserDto
        {
            Name = name,
            Email = email,
            Address = address,
            Phone = phone,
            UserType = userType,
            Money = decimal.Parse(money)
        };

        var validUser = _userService.ValidateUser(userDto);


        if (!validUser.Result.IsSuccess) return Ok(validUser.Result);

        var registerUser = await _userService.CreateUser(userDto);

        return Ok(registerUser);
    }
}