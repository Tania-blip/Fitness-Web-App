using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Components.Pages;

public partial class ExercisesPage : ComponentBase
{
    [Inject]
    public IExerciseRepository ExerciseRepository { get; set; }
    [Inject]
    public NavigationManager Navigation { get; set; }
    
    
    public List<ExerciseDto> ExercisesList;
    
    protected override void OnInitialized()
    {
        ExercisesList = ExerciseRepository.getExercises().ToList();
       
    }
    
    private void EditExercise(EditCommandContext<ExerciseDto> context)
    {
        if (context != null && context.Item != null)
        { 
            Navigation.NavigateTo($"/exercise/edit/{context.Item.Id}");
        }
    }
    
    private ExerciseDto SelectedExercise;
    private DeleteConfirmationDialog DeleteConfirmation;
    private void OnDeleteButtonClicked(CommandContext<ExerciseDto?> context)
    {
        SelectedExercise = context.Item;
        if (DeleteConfirmation is null || SelectedExercise is null)
        {
            return;
        }

        DeleteConfirmation.Show();
    }

    private async Task HandleDeleteConfirmed(bool confirmed)
    {
        if (SelectedExercise != null)
        {
            ExerciseRepository.DeleteExercise(SelectedExercise.Id);
            OnInitialized();
        }  
    }
}