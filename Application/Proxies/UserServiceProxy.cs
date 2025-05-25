using Application.DTOs.User;
using Application.Interfaces;
using Infrastructure;

public class UserServiceProxy : IUserService
{
    private readonly IUserService _inner;

    public UserServiceProxy(IUserService inner)
    {
        _inner = inner;
    }

    private void CheckAdminRole()
    {
        if (Session.Instance.UserRole != "Admin")
        {
            throw new UnauthorizedAccessException("User is not authorized to perform this action.");
        }
    }

    public async Task Create(CreateUserDto dto)
    {
        CheckAdminRole();
        await _inner.Create(dto);
    }

    public async Task<UserDto?> GetByUsername(string username)
    {
        return await _inner.GetByUsername(username);
    }

    public Task Delete(int id)
    {
        CheckAdminRole();
        return _inner.Delete(id);
    }

    public Task<IEnumerable<UserDto>> GetAll()
    {
        CheckAdminRole();
        return _inner.GetAll();
    }

    public Task<UserDto?> GetById(int id)
    {
        CheckAdminRole();
        return _inner.GetById(id);
    }

    public Task Update(int id, UpdateUserDto dto)
    {
        CheckAdminRole();
        return _inner.Update(id, dto);
    }
}
