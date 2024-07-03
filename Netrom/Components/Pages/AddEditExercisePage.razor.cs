

using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using Netrom.Entities;
using Netrom.Repositories.Implementations;
using Netrom.Repositories.Interfaces;


namespace Netrom.Components.Pages
{
    public partial class AddEditExercisePage : ComponentBase
    {
        [Inject] public IExerciseRepository exerciseRepository { get; set; }

        [SupplyParameterFromForm]
        public Exercises Exercise { get; set; } = new Exercises();
        [Inject]
        public NavigationManager Navigation { get; set; }
        public void SaveExercise()
        {
            exerciseRepository.Add(Exercise);
            Navigation.NavigateTo("/exercises");
            
        }
    }
}