﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;

namespace Sat.Recruitment.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly List<User>  _users = new List<User>();

        public UserRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public async Task<Result> CreateUser(User user)
        {
            var result = new Result
            {
                IsSuccess = true,
                MessagesErrors = new List<Error>()
            };
            
            user.Email = NormalizeEmail(user.Email);

            var gift = CalculateGift(user);
            user.Money += gift;

            await ReadUsersFromFile();

            //var rowList = FileReader.ReadFromFile(',', _appSettings.FileRoute);
           
            foreach (var userList in _users)
            {
                var duplicationMessage = _appSettings.UserDuplicated;
                if (user.Email == userList.Email || user.Phone == userList.Phone)
                {
                    Debug.WriteLine($"{duplicationMessage} {user.Email} {user.Phone} ");
                    result.IsSuccess = false;
                    result.MessagesErrors.Add(new Error(ErrorTypes.Duplication, _appSettings.UserDuplicated));
                }
                else if (user.Name == userList.Name)
                {
                    if (user.Address == userList.Address)
                    {
                        Debug.WriteLine($"{duplicationMessage} {user.Name} {user.Address} ");
                        result.IsSuccess = false;
                        result.MessagesErrors.Add(new Error(ErrorTypes.Duplication, _appSettings.UserDuplicated));
                    }

                }
            }

            if (result.IsSuccess)
            {
                Debug.WriteLine(_appSettings.UserCreated);
            }


            return Task.FromResult(result);
        }

        private static string NormalizeEmail(string email)
        {
            var parts = email.Split('@');
            var username = parts[0].Split('+')[0].Replace(".", "");
            var domain = parts[1];

            return $"{username}@{domain}";
        }

        public async Task ReadUsersFromFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Users.txt");

            await using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new StreamReader(fileStream);

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var userFields = line.Split(',');
                var user = new User
                {
                    Name = userFields[0].Trim(),
                    Email = userFields[1].Trim(),
                    Phone = userFields[2].Trim(),
                    Address = userFields[3].Trim(),
                    UserType = Enum.Parse<UserType>(userFields[4].Trim()),
                    Money = decimal.Parse(userFields[5].Trim(), CultureInfo.InvariantCulture),
                };
                _users.Add(user);
            }
        }

        //private decimal CalculateGift(User user)
        //{
        //    var rules = new List<Func<User, decimal>>
        //    {
        //        (u) => u.UserType == _appSettings.Normal && u.Money > 100 ? u.Money * 0.12m :  0,

        //        (u) => u.UserType == _appSettings.Normal && (u.Money < 100 && u.Money > 10)  ? u.Money * 0.8m : 0,

        //        (u) => u.UserType == _appSettings.SuperUser && u.Money > 100 ? u.Money * 0.20m : 0,

        //        (u) => u.UserType == _appSettings.Premium && u.Money > 100 ? u.Money * 2 : 0
        //    };

        //    return rules.Sum(rule => rule(user));
        //}

        private decimal CalculateGift(User user)
        {
            decimal NormalGift1(User u) => u.UserType == _appSettings.Normal && u.Money > 100 ? u.Money * 0.12m : 0;
            decimal NormalGift2(User u) => u.UserType == _appSettings.Normal && u.Money is >= 10 and <= 100 ? u.Money * 0.8m : 0;
            decimal SuperUserGift(User u) => u.UserType == _appSettings.SuperUser && u.Money > 100 ? u.Money * 0.20m : 0;
            decimal PremiumGift(User u) => u.UserType == _appSettings.Premium && u.Money > 100 ? u.Money * 2 : 0;

            var rules = new List<Func<User, decimal>> { NormalGift1, NormalGift2, SuperUserGift, PremiumGift };

            return rules.Sum(rule => rule(user));
        }

    }
}
