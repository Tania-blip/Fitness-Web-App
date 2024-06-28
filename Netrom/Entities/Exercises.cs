using Blazornetrom.Entites;

namespace Netrom.Entities;

public class Exercises
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public ICollection<ExerciseLog> ExercisesLogs { get; set; }
}