using System.ComponentModel.DataAnnotations;
using Blazornetrom.Entites;

namespace Netrom.Components.Models;

public class ExerciseDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Type is required")]
    public string Type { get; set; }
    
    public ICollection<ExerciseLog> ExercisesLogs { get; set; }
    
    public bool Exists { get; set; } = true;
}