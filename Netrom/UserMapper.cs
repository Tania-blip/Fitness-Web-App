using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom;

public class UserMapper
{
    public static User ToUser(UserDto userDto)
    {
        return new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Birthday = userDto.Birthday,
            Gender = userDto.Gender,
            Id = userDto.Id
        };
    }

    public static UserDto ToUserDto(User user)
    {
        return new UserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Birthday = user.Birthday,
            Gender = user.Gender,
            Id = user.Id
        };
    }
}