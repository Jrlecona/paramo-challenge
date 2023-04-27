namespace Sat.Recruitment.Application.Dtos;

public class ResultDto
{
    public bool IsSuccess { get; set; }
    public List<ErrorDto> Errors { get; set; }
}