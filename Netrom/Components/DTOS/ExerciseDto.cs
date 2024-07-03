using System.ComponentModel.DataAnnotations;
using Blazornetrom.Entites;

namespace Netrom.Components.Models;

public class ExerciseDto
{
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    public ICollection<ExerciseLog> ExercisesLogs { get; set; }
}