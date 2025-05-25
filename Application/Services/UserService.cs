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
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> GetById(int id)
        {
            throw new NotImplementedException();
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

        public Task Update(int id, UpdateUserDto dto)
        {
            throw new NotImplementedException();
        }

        //private ProductDto ToDto(Product product) => new ProductDto
        //{
        //    Id = product.Id,
        //    Title = product.Title,
        //    Description = product.Description,
        //    Code = product.Code,
        //    Article = product.Article,
        //    CategoryId = product.CategoryId,
        //    CategoryTitle = product.Category.Title
        //};
        private UserDto ToDto(User user) => new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Role = user.Role
        };

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}
