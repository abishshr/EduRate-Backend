using System.Linq;
using EduRate.Api.Data;
using EduRate.Api.Interfaces;
using EduRate.Api.Models;
using EduRate.Api.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace EduRate.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(AppDbContext dbContext, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        public bool Register(User user)
        {
            if (!_dbContext.Users.Any(u => u.Email == user.Email))
            {
                if (user.Email.EndsWith("@uol.com"))
                {
                    user.Password = _passwordHasher.HashPassword(user, user.Password);
                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public string Authenticate(LoginRequest request)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == request.Email);

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return TokenUtils.GenerateJwtToken(user, _configuration);
        }

        public User Login(LoginRequest request)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == request.Email);
            if (user != null && _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) != PasswordVerificationResult.Failed)
            {
                return user;
            }

            return null;
        }

        public User Logout(int userId, string token)
        {
            // Invalidate the token by adding it to a blacklist
            if (!string.IsNullOrEmpty(token))
            {
                BlacklistUtils.BlacklistToken(token);
            }

            return GetProfile(userId);
        }

        public User GetProfile(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public User UpdateProfile(User user)
        {
            var existingUser = _dbContext.Users.Find(user.Id);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                _dbContext.SaveChanges();
                return existingUser;
            }

            return null;
        }
    }
}
