using System.Security.Claims;
using Blazorise.DataGrid;
using Blazornetrom.Entites;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Netrom.Components.Models;
using Netrom.Components.Services.Implementations;
using Netrom.Entities;
using Netrom.Repositories.Implementations;
using Netrom.Repositories.Interfaces;
using Netrom.Services.Interfaces;

namespace Netrom.Components.Pages;

public partial class Workouts : ComponentBase
{
    [Inject]
    public IWorkoutRepository WorkoutRepository { get; set; }
    
[Inject]
    public IUserRepository UserRepository { get; set; }


    [Parameter]
    public int UserId { get; set; }
    
    private Dictionary<int, ICollection<ExerciseLog>> WorkoutExerciseLogs = new Dictionary<int, ICollection<ExerciseLog>>();
    
    
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    [Inject]
    public AuthenticationStateProvider AuthStateProvider { get; set; }
    
    public void AddExerciseLog(Workout context)
    {
        Navigation.NavigateTo($"/exerciseLog/add/{context.Id}");
        
    }

    private Workout SelectedWorkout;
    private DeleteConfirmationDialog DeleteConfirmation;
    
    private void OnDeleteButtonClicked(Workout? context)
    {
        SelectedWorkout = context;
        if (DeleteConfirmation is null || SelectedWorkout is null)
        {
            return;
        }

        DeleteConfirmation.Show();
    }

    private async Task HandleDeleteConfirmed(bool confirmed)
    {
        if (SelectedWorkout != null)
        {
            WorkoutRepository.DeleteWorkout(SelectedWorkout.Id);
            OnInitialized();
        }  
    }
    
    private int totalWorkouts;
    private int currentPage = 1;
    private int pageSize = 9;
    private int totalPages => (int)Math.Ceiling((double)totalWorkouts / pageSize);
    
    public List<Workout> WorkoutList = new List<Workout>();
    protected override async Task OnInitializedAsync()
    {
        await LoadData(1);
    }

    private async Task LoadData(int pageNumber)
    {
        (IEnumerable<Workout> Workouts, int TotalCount) result;

        AuthenticationState loggedUserState = await AuthStateProvider.GetAuthenticationStateAsync();
        User loggedUser = UserRepository.getUserByEmail(loggedUserState.User.FindFirst(ClaimTypes.Name).Value);
        if (loggedUser is { IsTrainer: true })
        {
            if (UserId != 0)
                result = await WorkoutRepository.GetWorkoutsAsync(pageNumber, pageSize, UserId);
            else
                result = await WorkoutRepository.GetWorkoutsAsync(pageNumber, pageSize);
        }
        else
        {
            result = await WorkoutRepository.GetWorkoutsAsync(pageNumber, pageSize, loggedUser.Id);

        }

        WorkoutList = result.Workouts.ToList();
        totalWorkouts = result.TotalCount;
        currentPage = pageNumber;
    }

    private async void ChangePage(int newPage)
    {
        if (newPage > 0 && newPage <= totalPages)
        {
           await LoadData(newPage);
        }
    }

    private bool IsPreviousDisabled => currentPage <= 1;
    private bool IsNextDisabled => currentPage >= totalPages;
    
    
}