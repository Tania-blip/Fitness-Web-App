using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class AddUserPage : ComponentBase
{
    [Inject]
    public IUserRepository UserRepository { get; set; }
    
    [SupplyParameterFromForm]
    public User User { get; set; } = new User();
    
    public async Task SaveUser()
    {
        await UserRepository.AddAsync(User);
        Navigation.NavigateTo("/clients");
    }
   
}