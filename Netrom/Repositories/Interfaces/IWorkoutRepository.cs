using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IWorkoutRepository
{
    ICollection<Workout> getWorkouts();
}