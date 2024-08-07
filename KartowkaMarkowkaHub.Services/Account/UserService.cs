﻿using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.DTO.Account;

namespace KartowkaMarkowkaHub.Services.Account
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(UserDTO user)
        {

            var userSample = new User()
            {
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
            };

            var result = await _userRepository.AddAsync(userSample);

            return result;
        }
    }
}