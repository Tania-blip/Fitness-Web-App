using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Netrom.Components.Models;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class Clients : ComponentBase
{
    [Inject]
    public IUserRepository UserRepository { get; set; }
    
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    public List<UserDto> Users;
        
    protected override void OnInitialized()
    {
        Users = UserRepository.getUsers().ToList();
    }
    
    private void EditUser(EditCommandContext<UserDto> context)
    {
        if (context != null && context.Item != null)
        {
            Navigation.NavigateTo($"/user/edit/{context.Item.Id}");
        }
    }
    private UserDto SelectedUser;
    private DeleteConfirmationDialog DeleteConfirmation;
    
    // private void OnDeleteButtonClicked(CommandContext<UserDto?> context)
    // {
    //     SelectedUser = context.Item;
    //     if (DeleteConfirmation is null || SelectedUser is null)
    //     {
    //         return;
    //     }
    //
    //     DeleteConfirmation.Show();
    // }
    
    private void OnDeleteButtonClicked(UserDto? context)
    {
        SelectedUser = context;
        if (DeleteConfirmation is null || SelectedUser is null)
        {
            return;
        }

        DeleteConfirmation.Show();
    }

    private async Task HandleDeleteConfirmed(bool confirmed)
    {
        if (SelectedUser != null)
        {
            UserRepository.DeleteUser(SelectedUser.Id);
            OnInitialized();
        }  
    }

    // public void AddWorkout(EditCommandContext<UserDto> context)
    // {
    //     Navigation.NavigateTo($"/addWorkout/{context.Item.Id}");
    //     
    // }
    
    public void AddWorkout(UserDto context)
    {
        Navigation.NavigateTo($"/addWorkout/{context.Id}");
        
    }
    
    private List<UserDto> UserList = new List<UserDto>();
    private int totalUsers;
    private int currentPage = 1;
    private int pageSize = 5;
    private int totalPages => (int)Math.Ceiling((double)totalUsers / pageSize);
    protected override async Task OnInitializedAsync()
    {
        await LoadData(1);
    }

    private async Task LoadData(int pageNumber)
    {
        var result = await UserRepository.GetUsersAsync(pageNumber, pageSize);
        Users = result.Users.ToList();
        totalUsers = result.TotalCount;
        currentPage = pageNumber;
    }

    private void ChangePage(int newPage)
    {
        if (newPage > 0 && newPage <= totalPages)
        {
            LoadData(newPage);
        }
    }

    private bool IsPreviousDisabled => currentPage <= 1;
    private bool IsNextDisabled => currentPage >= totalPages;
}