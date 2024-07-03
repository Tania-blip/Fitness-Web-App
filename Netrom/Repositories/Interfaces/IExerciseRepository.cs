using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IExerciseRepository
{
    ICollection<Exercises> getExercises();
    void Add(Exercises exercise);
}