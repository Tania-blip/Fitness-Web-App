using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom.Repositories.Interfaces;

public interface IExerciseRepository
{
    ICollection<ExerciseDto> getExercises();
    Task Add(ExerciseDto exerciseDto);
    ExerciseDto getExerciseById(int? Id);
    void UpdateExercise(int? id, ExerciseDto exercise);
    void DeleteExercise(int id);
    Task<(IEnumerable<ExerciseDto> Exercises, int TotalCount)> GetExerciseAsync(int pageIndex, int pageSize);
}