using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Domain.Interfaces;

public interface IUserRepository
{
    public Task<Result> CreateUser(User user);

    public Task<Result> ValidateUser(User user);
}