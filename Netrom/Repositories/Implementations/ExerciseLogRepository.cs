using Blazornetrom.Context;
using Blazornetrom.Entites;
using Netrom.Repositories.Interfaces;

namespace Netrom.Repositories.Implementations;

public class ExerciseLogRepository : IExerciseLogRepository
{
    public readonly SmartWorkoutContext _context;

    public ExerciseLogRepository(SmartWorkoutContext context)
    {
        _context = context;
    }
    public ICollection<ExerciseLog> getExerciseLogs()
    {
        var exerciseLogs = _context.ExercisesLogs.ToList();
        return exerciseLogs;
    }
}