using Blazornetrom.Context;
using Microsoft.AspNetCore.Identity;
using Netrom.Components.Models;
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

    public async Task AddAsync(UserDto userDto)
    {
        User user = new User()
        {
            FirstName = userDto.FirstName,
            Birthday = userDto.Birthday,
            LastName = userDto.LastName,
            Gender = userDto.Gender
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    
    public void UpdateUser(int? id, UserDto user)
    {
        User userToUpdate = _context.Users.FirstOrDefault(x => x.Id == id);

        if (userToUpdate != null)
        {    
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Birthday = user.Birthday;
            userToUpdate.Gender = user.Gender;
            _context.Users.Update(userToUpdate);
            _context.SaveChanges();

        }
        else
        {
            throw new Exception($"User with id {id} not found!");
        }
    }

    public async Task<User> getUserByIdAsync(int Id)
    {
        var user = await _context.Users.FindAsync(Id);
        return user;
    }
    
    public UserManager<User> UserManager;
    public UserDto getUserById(int? Id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == Id);
        UserDto userDto = new UserDto();

        if (user == null)
        {
            userDto.Exists = false;
        }
        
        userDto.FirstName = user.FirstName;
        userDto.Birthday = user.Birthday;
        userDto.LastName = user.LastName;
        userDto.Gender = user.Gender;
        
        return userDto;
    }

}