using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Domain.Entities;

public class Error
{
    public Error(ErrorTypes type, string message)
    {
        Type = type;
        Message = message;
    }

    public ErrorTypes Type { get; set; }
    public string Message { get; set; }
}