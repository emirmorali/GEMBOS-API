﻿using BCrypt.Net;
using GembosAPI.BusinessLayer.ServiceInterfaces;
using GembosAPI.DataAccessLayer.RepositoryInterfaces;
using GembosAPI.EntityLayer.DTOs;
using GembosAPI.EntityLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GembosAPI.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByPhoneNumberAsync(loginDTO.PhoneNumber);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.PhoneNumber)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> RegisterAsync(RegisterDTO registerDTO)
        {
            if (!registerDTO.Password.Equals(registerDTO.verifyPassword))
            {
                return null;
            }

            var newUser = new User
            {
                PhoneNumber = registerDTO.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                Name = registerDTO.Name,
                Surname = registerDTO.Surname
            };

            await _userRepository.AddUserAsync(newUser);
            return newUser;
        }

        public async Task<bool> SyncUserAsync(UserDTO userDTO)
        {
            var existingUser = await _userRepository.GetUserByPhoneNumberAsync(userDTO.PhoneNumber);
            if (existingUser != null)
            {
                return true;
            }

            var user = new User
            {
                PhoneNumber = userDTO.PhoneNumber,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                Password = userDTO.Password
            };

            await _userRepository.AddUserAsync(user);
            return true;
        }
    }
}
