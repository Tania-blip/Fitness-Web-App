using Blazornetrom.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public ICollection<UserDto> getUsers()
    {
        // var users = _context.Users.ToList();
        // return users;
        return _context.Users.Select(u => UserMapper.ToUserDto(u)).ToList();
    }

    public async Task AddAsync(UserDto userDto)
    {
        User user = new User()
        {
            FirstName = userDto.FirstName,
            Birthday = userDto.Birthday,
            LastName = userDto.LastName,
            Gender = userDto.Gender,
            Email = userDto.Email
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
            userToUpdate.Email = user.Email;
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
        userDto.Email = user.Email;
        
        return userDto;
    }
    
    public void DeleteUser(int id)
    {
        var existingUser = _context.Users.Find(id);
        if (existingUser != null)
        {
            _context.Users.Remove(existingUser);
            _context.SaveChanges();
        }
    }
    
    public async Task<(IEnumerable<UserDto> Users, int TotalCount)> GetUsersAsync(int pageIndex, int pageSize)
    {
        var query = _context.Users.AsQueryable();
        var totalCount = await query.CountAsync();
        var users = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        var userDtos = users.Select(user => new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Birthday = user.Birthday,
            Gender = user.Gender,
            Email = user.Email
        }).ToList();

        return (userDtos, totalCount);
    }

    public User getUserByEmail(string? Email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == Email);

        if (user == null)
        {
            return null;
        }

        return user;
    }

}