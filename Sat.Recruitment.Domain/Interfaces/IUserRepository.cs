using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<Result> CreateUser(User user);
        //Task<bool> CheckIfUserExists(string email, string phone, string name, string address);
        public Task<Result> ValidateUser(User user);
    }
}
