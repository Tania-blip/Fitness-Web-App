using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IWorkoutRepository
{
    ICollection<Workout> getWorkouts();
    
    Task AddAsync(Workout workout);
    Task<(IEnumerable<Workout> Workouts, int TotalCount)> GetWorkoutsAsync(int pageIndex, int pageSize, int userId = -1);

    ICollection<Workout> getWorkoutForUser(int userId);

    void DeleteWorkout(int id);
}