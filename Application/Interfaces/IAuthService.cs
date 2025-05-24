using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
        Task Register(UserRegisterDto dto);
    }
}
