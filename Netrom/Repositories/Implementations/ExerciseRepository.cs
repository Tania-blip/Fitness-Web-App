using Blazornetrom.Context;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Repositories.Implementations;

public class ExerciseRepository : IExerciseRepository
{
    public readonly SmartWorkoutContext _context;

    public ExerciseRepository(SmartWorkoutContext context)
    {
        _context = context;
    }
    public ICollection<Exercises> getExercises()
    {
        var exercises = _context.Exercises.ToList();
        return exercises;
    }
    
    public void Add(Exercises exercise)
    {
        _context.Exercises.Add(exercise);
         _context.SaveChanges();
    }
}