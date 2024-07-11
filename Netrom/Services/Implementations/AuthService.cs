using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Netrom.Authentication;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;
using Netrom.Services.Interfaces;


namespace Netrom.Components.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly CustomAuthStateProvider _customAuthStateProvider;
        
        public AuthService(IUserRepository userRepository, AuthenticationStateProvider _authenticationStateProvider)
        {
            _userRepository = userRepository;
            _customAuthStateProvider = (CustomAuthStateProvider)_authenticationStateProvider;
        }
        
        public void Login(LoginDto loginDto)
        {
            var loggedUser = _userRepository.getUserByEmail(loginDto.email);
            if (loggedUser == null)
            {
                throw new Exception("Wrong username or password");
            }
            if (loginDto.code != loggedUser.Birthday.ToString("MMyyyy"))
            {
                throw new Exception("Wrong password");
            }

            _customAuthStateProvider.UpdateAuthenticationState(loggedUser);

        }

        public void LogOut()
        {
            _customAuthStateProvider.UpdateAuthenticationState(null);
        }
        
    }
}