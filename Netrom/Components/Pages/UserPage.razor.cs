using Microsoft.AspNetCore.Components;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class UserPage : ComponentBase
{
    [Inject]
    public IUserRepository UserRepository { get; set; }

    public List<User> Users;
        
    protected override void OnInitialized()
    {
            
        Users = UserRepository.getUsers().ToList();
    }
}