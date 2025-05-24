using Application.DTOs.Product;
using Application.DTOs.User;
using Application.Interfaces;
using Domain.Entitites;
using Domain.Interfaces;

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

        public Task<UserDto> Create(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
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

    }
}
