using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IUserRepository
{
    ICollection<User> getUsers();
    Task AddAsync(User user);

}