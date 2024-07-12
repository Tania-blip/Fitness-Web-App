using Microsoft.AspNetCore.Components;
using Netrom.Components.Models;
using Netrom.Components.Services.Implementations;
using Netrom.Entities;
using Netrom.Repositories.Implementations;
using Netrom.Repositories.Interfaces;
using Netrom.Services.Interfaces;

namespace Netrom.Components;

public partial class LoginPage : ComponentBase
{
    [Parameter]
    public string Email { get; set; }
    public string Code { get; set; }
    
    
    [Inject]
    private NavigationManager Navigation { get; set; }
    
    [Inject]
    public IUserRepository UserRepository { get; set; }
    
    [Inject]
    public IAuthService AuthService { get; set; }

    [SupplyParameterFromForm] public LoginDto loginDto { get; set; } = new LoginDto();
    
    public string ErrorMessage { get; set; }

    public void SignIn()
    {
        try
        {
            AuthService.Login(loginDto);
            Navigation.NavigateTo("/users", true);
        }
        catch (Exception e)
        {
            ErrorMessage = "Failed to sign in: " + e.Message;
            Console.WriteLine(e);
        }
    }

    
}