using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class AddWorkoutPage : ComponentBase
{
    [Inject]
    public IWorkoutRepository WorkoutRepository { get; set; }
    
    [SupplyParameterFromForm]
    public Workout Workout { get; set; } = new Workout();
    
    public async Task SaveWorkout()
    {
        await WorkoutRepository.AddAsync(Workout);
        Navigation.NavigateTo("/workouts");
    }
}