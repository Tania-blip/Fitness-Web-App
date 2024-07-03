using System.ComponentModel.DataAnnotations;
using Netrom.Entities;

namespace Netrom.Components.Models;

public class ExerciseLogDto
{
    [Required]
    public int Reps {  get; set; }
    [Required]
    public int Duration { get; set; }
    
    public int ExerciseId { get; set; }
    public Exercises Exercises { get; set; }

    public int WorkoutId {  get; set; }
    public Workout Workouts { get; set; }  
}