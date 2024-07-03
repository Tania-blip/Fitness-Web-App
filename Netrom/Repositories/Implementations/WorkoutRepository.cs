using Blazornetrom.Context;
using Microsoft.EntityFrameworkCore;
using Netrom.Components.Pages;
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
    
    public async Task AddAsync(Workout workout)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
    }
    
}