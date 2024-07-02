using Blazornetrom.Entites;
using Microsoft.AspNetCore.Components;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class ExercisesLogPage : ComponentBase
{
    [Inject]
    public IExerciseLogRepository ExerciseLogRepository { get; set; }
    public List<ExerciseLog> ExerciseLogList;
    protected override void OnInitialized()
    {
       ExerciseLogList = ExerciseLogRepository.getExerciseLogs().ToList();
    }
}