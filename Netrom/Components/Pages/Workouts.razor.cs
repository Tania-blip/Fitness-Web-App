using Microsoft.AspNetCore.Components;
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
}