using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IUserRepository
{
    ICollection<User> getUsers(); //de modificat cu userDto
    Task AddAsync(UserDto user);
    UserDto getUserById(int? Id);

    void UpdateUser(int? id, UserDto user);

}