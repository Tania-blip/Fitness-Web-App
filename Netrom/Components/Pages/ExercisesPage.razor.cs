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
    
    private void EditExercise(ExerciseDto context)
    {
        if (context != null)
        { 
            Navigation.NavigateTo($"/exercise/edit/{context.Id}");
        }
    }
    
    private ExerciseDto SelectedExercise;
    private DeleteConfirmationDialog DeleteConfirmation;
    private void OnDeleteButtonClicked(ExerciseDto? context)
    {
        SelectedExercise = context;
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
    
   // private List<ExerciseDto> ExerciseList = new List<ExerciseDto>();
    private int totalExercises;
    private int currentPage = 1;
    private int pageSize = 9;
    private int totalPages => (int)Math.Ceiling((double)totalExercises / pageSize);
    protected override async Task OnInitializedAsync()
    {
        await LoadData(1);
    }

    private async Task LoadData(int pageNumber)
    {
        var result = await ExerciseRepository.GetExerciseAsync(pageNumber, pageSize);
        ExercisesList = result.Exercises.ToList();
        totalExercises = result.TotalCount;
        currentPage = pageNumber;
    }

    private void ChangePage(int newPage)
    {
        if (newPage > 0 && newPage <= totalPages)
        {
            LoadData(newPage);
        }
    }

    private bool IsPreviousDisabled => currentPage <= 1;
    private bool IsNextDisabled => currentPage >= totalPages;
}