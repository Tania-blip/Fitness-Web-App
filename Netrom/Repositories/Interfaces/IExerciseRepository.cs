using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IExerciseRepository
{
    ICollection<ExerciseDto> getExercises();
    //void Add(ExerciseDto exercise);
    Task Add(ExerciseDto exerciseDto);

    ExerciseDto getExerciseById(int? Id);

    void UpdateExercise(int? id, ExerciseDto exercise);
    void DeleteExercise(int id);
}