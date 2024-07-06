using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IUserRepository
{
    ICollection<UserDto> getUsers(); //de modificat cu userDto
    Task AddAsync(UserDto user);
    UserDto getUserById(int? Id);

    void UpdateUser(int? id, UserDto user);
    //Task DeleteUser(int? id);
    void DeleteUser(int id);
    Task<(IEnumerable<UserDto> Users, int TotalCount)> GetUsersAsync(int pageIndex, int pageSize);
}