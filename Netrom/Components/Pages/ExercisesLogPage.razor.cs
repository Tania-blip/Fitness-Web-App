using Blazornetrom.Entites;
using Microsoft.AspNetCore.Components;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class ExercisesLogPage : ComponentBase
{
    [Inject]
    public IExerciseLogRepository ExerciseLogRepository { get; set; }
    public List<ExerciseLog> ExerciseLogList;
    
    [Parameter]
    public int workoutId { get; set; }
    
    protected override void OnInitialized()
    {
        if (workoutId == 0)
        {
            ExerciseLogList = ExerciseLogRepository.getExerciseLogs().ToList();
        }
        else
        {
            ExerciseLogList = ExerciseLogRepository.getExerciseLogsForWorkout(workoutId).ToList();
        }
        
       
    }
    
}