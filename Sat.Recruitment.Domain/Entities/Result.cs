namespace Sat.Recruitment.Domain.Entities;

public class Result
{
    public bool IsSuccess { get; set; }
    public List<Error> MessagesErrors { get; set; }
}