using System.ComponentModel.DataAnnotations;
using Blazornetrom.Entites;
using Netrom.Entities;

namespace Netrom.Components.Models;

public class WorkoutDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Date is required")]
    public DateTime Date { get; set; }
    
    public int UserId { get; set; }
    
    [Required(ErrorMessage = "User is required")]
    public User User { get; set; }

    public ICollection<ExerciseLog> ExercisesLogs;
}