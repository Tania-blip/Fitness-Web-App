using Blazornetrom.Context;
using Blazornetrom.Entites;
using Microsoft.EntityFrameworkCore;
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
        var exerciseLogs = _context.ExercisesLogs
            .Include(x=>x.Exercises)
            .Include(l => l.Workouts)
            .ToList();
        
        return exerciseLogs;
    }
    
    public async Task Add(ExerciseLog exerciseLog)
    {
        _context.ExercisesLogs.Add(exerciseLog);
        await _context.SaveChangesAsync();
    }

    public ICollection<ExerciseLog> getExerciseLogsForWorkout(int WorkoutId)
    {
        return _context.ExercisesLogs
            .Include(l => l.Workouts)
            .Include(x=>x.Exercises).Where(log => log.WorkoutId == WorkoutId).ToList();
        
    }
}