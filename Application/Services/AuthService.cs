using Application.DTOs;
using Application.Interfaces;
using Domain.Entitites;
using Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;

    public AuthService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<bool> Login(string username, string password)
    {
        var user = await _userRepo.GetByUsernameAsync(username);
        if (user == null) return false;

        var hash = HashPassword(password);
        return user.PasswordHash == hash;
    }

    public async Task Register(UserRegisterDto dto)
    {
        var existing = await _userRepo.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("User already exists");

        var user = new User
        {
            Username = dto.Username,
            PasswordHash = HashPassword(dto.Password),
        };

        await _userRepo.CreateAsync(user);
    }

    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
