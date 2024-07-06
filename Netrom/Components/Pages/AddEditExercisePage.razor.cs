

using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Implementations;
using Netrom.Repositories.Interfaces;


namespace Netrom.Components.Pages
{
    public partial class AddEditExercisePage : ComponentBase
    {
        [Inject] public IExerciseRepository exerciseRepository { get; set; }

        [SupplyParameterFromForm]
        public ExerciseDto ExerciseDto { get; set; } = new ExerciseDto();
        [Inject]
        public NavigationManager Navigation { get; set; }
        
        [Parameter]
        public int? ExerciseId { get; set; }

        private bool isEdit = false;
        public async Task SaveExercise()
        {
            if (isEdit)
            {
                exerciseRepository.UpdateExercise(ExerciseId, ExerciseDto);
            }
            else
            {
                await exerciseRepository.Add(ExerciseDto);
            }
            
            Navigation.NavigateTo("/exercises");
            
        }
        
        protected override void OnParametersSet()
        {
            if (ExerciseId != null)
            {
                isEdit = true;
                ExerciseDto = exerciseRepository.getExerciseById(ExerciseId);
            }
        }
    }
}