using Blazornetrom.Entites;
using Microsoft.AspNetCore.Components;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class AddExerciseLogPage : ComponentBase
{
    [Inject]
    public IExerciseLogRepository exerciseLogRepository { get; set; }
    
    [Inject]
    
    public IExerciseRepository exerciseRepository { get; set; }

    [SupplyParameterFromForm]
    public ExerciseLog ExerciseLog { get; set; } = new ExerciseLog();
    
    [Inject]
    public NavigationManager Navigation { get; set; }

    public ICollection<ExerciseDto> ExercisesList = new List<ExerciseDto>();
    
    [Parameter]
    public int workoutId { get; set; }
   //public int exerciseId { get; set; }
    public async Task SaveExerciseLog()
    {
        // await exerciseLogRepository.Add(ExerciseLog);
        // Navigation.NavigateTo("/workouts");
        if (ExercisesList.Any(x => x.Id == ExerciseLog.ExerciseId))
        {
            await exerciseLogRepository.Add(ExerciseLog);
            Navigation.NavigateTo("/workouts");
        }
        else
        {
            // Manage error, e.g., show an error message or log it.
            Console.WriteLine("Invalid Exercise ID");
        }
            
    }

    protected override void OnParametersSet()
    {
        ExercisesList = exerciseRepository.getExercises().ToList();
        if (!ExercisesList.Any())
        {
            throw new InvalidOperationException("No exercises available.");
        }
        // Debugging to verify that the list is correctly populated
        foreach (var exercise in ExercisesList)
        {
            Console.WriteLine($"Exercise ID: {exercise.Id}, Description: {exercise.Description}");
        }
    }
    

    protected override void OnInitialized()
    {
        
        ExercisesList = exerciseRepository.getExercises().ToList();
        ExerciseLog.WorkoutId = workoutId;  // Asigură-te că acesta este setat corect
    }


}