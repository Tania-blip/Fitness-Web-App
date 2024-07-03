using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class AddUserPage : ComponentBase
{
    [Inject]
    public IUserRepository UserRepository { get; set; }
    
    [SupplyParameterFromForm]
    public UserDto UserDto { get; set; } = new UserDto();
    
    [Parameter]
    public int? UserId { get; set; }

    private bool isEdit = false;
    protected override void OnParametersSet()
    {
        if (UserId != null)
        {
            isEdit = true;
            UserDto = UserRepository.getUserById(UserId);
        }
    }
    public async Task SaveUser()
    {
        if (isEdit)
        {
            UserRepository.UpdateUser(UserId, UserDto);
        }
        else
        {
            await UserRepository.AddAsync(UserDto);
        }

        Navigation.NavigateTo("/users");
    }
    
}