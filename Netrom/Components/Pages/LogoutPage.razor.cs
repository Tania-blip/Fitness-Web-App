using Microsoft.AspNetCore.Components;
using Netrom.Components.Services.Implementations;
using Netrom.Services.Interfaces;

namespace Netrom.Components.Pages;

public partial class LogoutPage : ComponentBase
{
    [Inject]
    NavigationManager Navigation { get; set; }
    [Inject]
    public IAuthService AuthService { get; set; }

    public void Logout()
    {
        AuthService.LogOut();
        Navigation.NavigateTo("/", true);
    }
}