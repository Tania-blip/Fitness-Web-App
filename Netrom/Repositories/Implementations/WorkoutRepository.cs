using Blazornetrom.Context;
using Microsoft.EntityFrameworkCore;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Repositories.Implementations;

public class WorkoutRepository : IWorkoutRepository
{
    
    public readonly SmartWorkoutContext _context;

    public WorkoutRepository(SmartWorkoutContext context)
    {
        _context = context;
    }
    public ICollection<Workout> getWorkouts()
    {
        var workouts = _context.Workouts.Include(x=>x.User).ToList();
        return workouts;
    }
    
}