using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class AddExercisePage : ComponentBase
{
    [Inject]
    public IExerciseRepository ExerciseRepository { get; set; }
    
    [SupplyParameterFromForm]
    public Exercises Exercise { get; set; } = new Exercises();
    
    public async Task SaveExercise()
    {
        await ExerciseRepository.AddAsync2(Exercise);
        Navigation.NavigateTo("/exercises");
    }
   
}