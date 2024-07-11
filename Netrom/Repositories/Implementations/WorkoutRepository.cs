using Blazornetrom.Context;
using Microsoft.EntityFrameworkCore;
using Netrom.Components.Models;
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

    public ICollection<Workout> getWorkoutForUser(int userId)
    {
        var workouts = _context.Workouts
            .Include(x=>x.User)
            .Where(w => w.UserId == userId).ToList();
        return workouts;
    }
    
    public async Task AddAsync(Workout workout)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
    }
    
    public async Task<(IEnumerable<Workout> Workouts, int TotalCount)> GetWorkoutsAsync(int pageIndex, int pageSize, int userId = -1)
    {
        // Start with the base query
        var query = _context.Workouts.AsQueryable();

        // Apply the userId filter if it is provided (not -1)
        if (userId != -1)
        {
            query = query.Where(w => w.UserId == userId);
        }

        // Get the total count of records matching the query
        var totalCount = await query.CountAsync();

        // Apply pagination and include related data
        var workouts = await query.Include(w => w.ExercisesLogs)
            .ThenInclude(el => el.Exercises)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        // Return the result as a tuple
        return (workouts, totalCount);
    }

    
    public void DeleteWorkout(int id)
    {
        var existingWorkout = _context.Workouts.Find(id);
        if (existingWorkout != null)
        {
            _context.Workouts.Remove(existingWorkout);
            _context.SaveChanges();
        }
    }
}