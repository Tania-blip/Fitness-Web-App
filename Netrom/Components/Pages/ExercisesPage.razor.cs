using Microsoft.AspNetCore.Components;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class ExercisesPage : ComponentBase
{
    [Inject]
    public IExerciseRepository ExerciseRepository { get; set; }
    public List<Exercises> ExercisesList;
    
    protected override void OnInitialized()
    {
        ExercisesList = ExerciseRepository.getExercises().ToList();
       
    }
}