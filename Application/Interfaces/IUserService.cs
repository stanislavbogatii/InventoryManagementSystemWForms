using Application.DTOs.User;


namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto?> GetById(int id);
        public Task<UserDto?> GetByUsername(string username);
        public Task<IEnumerable<UserDto>> GetAll();
        public Task Create(CreateUserDto dto);
        public Task Update(int id, UpdateUserDto dto);
        public Task Delete(int id);

    }
}
