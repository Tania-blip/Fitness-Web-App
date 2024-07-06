using Blazorise.DataGrid;
using Blazornetrom.Entites;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class Workouts : ComponentBase
{
    [Inject]
    public IWorkoutRepository WorkoutRepository { get; set; }
    public List<Workout> Workout;
    protected override void OnInitialized()
    {
        
        Workout = WorkoutRepository.getWorkouts().ToList();
    }
    
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    public void AddExerciseLog(EditCommandContext<Workout> context)
    {
        Navigation.NavigateTo($"/exerciseLog/add/{context.Item.Id}");
        
    }
}