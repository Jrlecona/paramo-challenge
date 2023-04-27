using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Dtos;

public class ErrorDto
{
    public ErrorDto(ErrorTypes type, string message)
    {
        Type = type;
        Message = message;
    }

    public ErrorTypes Type { get; set; }
    public string Message { get; set; }
}