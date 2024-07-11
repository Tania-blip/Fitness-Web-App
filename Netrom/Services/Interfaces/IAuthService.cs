using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom.Services.Interfaces;

public interface IAuthService
{

    void Login(LoginDto loginDto);
    void LogOut();
}