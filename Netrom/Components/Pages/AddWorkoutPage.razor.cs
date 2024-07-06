using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class AddWorkoutPage : ComponentBase
{
    [Inject]
    public IWorkoutRepository WorkoutRepository { get; set; }
    [Inject]
    public IUserRepository UserRepository { get; set; }

    [Parameter]
    public int UserId { get; set; }
    
    public UserDto UserToShow { get; set; }
    
    [SupplyParameterFromForm]
    public Workout Workout { get; set; } = new Workout();

    protected override void OnParametersSet()
    {
        var userId = UserId;
        UserToShow = UserRepository.getUserById(userId);
    }

    public async Task SaveWorkout()
    {
        Workout.UserId = UserId;
        await WorkoutRepository.AddAsync(Workout);
        Navigation.NavigateTo("/workouts");
    }
}