using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        void Register(UserRegisterDto dto);
    }
}
