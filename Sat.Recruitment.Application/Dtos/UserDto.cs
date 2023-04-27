using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Application.Dtos;

public class UserDto
{
    [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Address is required", AllowEmptyStrings = false)]
    public string Address { get; set; }

    [Required(ErrorMessage = "Phone is required", AllowEmptyStrings = false)]
    public string Phone { get; set; }

    public string UserType { get; set; }
    public decimal Money { get; set; }
}