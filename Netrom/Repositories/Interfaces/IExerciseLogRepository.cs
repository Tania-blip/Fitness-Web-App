using Blazornetrom.Entites;

namespace Netrom.Repositories.Interfaces;

public interface IExerciseLogRepository
{
    ICollection<ExerciseLog> getExerciseLogs();
    Task Add(ExerciseLog exerciseLog);

    ICollection<ExerciseLog> getExerciseLogsForWorkout(int WorkoutId);
}