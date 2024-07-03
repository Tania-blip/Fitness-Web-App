using System.ComponentModel.DataAnnotations;
using Blazornetrom.Entites;
using Netrom.Entities;

namespace Netrom.Components.Models;

public class WorkoutDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }

    public ICollection<ExerciseLog> ExercisesLogs;
}