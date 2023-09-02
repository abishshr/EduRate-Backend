using EduRate.Api.Models;

namespace EduRate.Api.Interfaces
{
    public interface IUserService
    {
        bool Register(User user);
        string Authenticate(LoginRequest request);
        User Login(LoginRequest request);
        User Logout(int userId, string token);
        User GetProfile(int userId);
        User UpdateProfile(User user);
    }
}