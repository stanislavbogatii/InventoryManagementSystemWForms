using Application.DTOs.User;
using Application.Interfaces;
using Domain.Entitites;
using Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task Delete(int id)
        {
            await _userRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepo.GetAllAsync();
            return users.Select(l => MapToDto(l)).ToList();
        }

        public async Task<UserDto?> GetById(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return ToDto(user);
        }

        public async Task<UserDto?> GetByUsername(string username)
        {
            var user = await _userRepo.GetByUsernameAsync(username);
            if (user is not null)
            {
                return ToDto(user);
            }
            return null;
        }

        public async Task Create(CreateUserDto dto)
        {

            var user = await _userRepo.GetByUsernameAsync(dto.Username);
            if (user is not null) throw new Exception("User with same username already exist");

            var hash = HashPassword(dto.Password);

            User newUser = new()
            {
                Username = dto.Username,
                Role = dto.Role,
                PasswordHash = hash
            };
            await _userRepo.CreateAsync(newUser);

        }

        public async Task Update(int id, UpdateUserDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user is null) throw new Exception("User not found");

            var hash = HashPassword(dto.Password);

            user.Username = user.Username;
            user.Role = dto.Role;
            user.PasswordHash = hash;
            await _userRepo.UpdateAsync(user);
        }

        private UserDto ToDto(User user) => new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Role = user.Role
        };

        public async Task<bool> AnyExists()
        {
            return await _userRepo.AnyExistsAsync();
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            };

        }
    }
}
