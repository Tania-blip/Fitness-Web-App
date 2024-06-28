using Blazornetrom.Context;

using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    public readonly SmartWorkoutContext _context;

    public UserRepository(SmartWorkoutContext context)
    {
        _context = context;
    }
    public ICollection<User> getUsers()
    {
        var users = _context.Users.ToList();
        return users;
    }
}