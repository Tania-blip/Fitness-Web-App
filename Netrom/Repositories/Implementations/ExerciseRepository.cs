using Blazornetrom.Context;
using Netrom.Components.Models;
using Netrom.Entities;
using Netrom.Repositories.Interfaces;

namespace Netrom.Repositories.Implementations;

public class ExerciseRepository : IExerciseRepository
{
    public readonly SmartWorkoutContext _context;

    public ExerciseRepository(SmartWorkoutContext context)
    {
        _context = context;
    }
    public ICollection<ExerciseDto> getExercises()
    {
        // var exercises = _context.Exercises.ToList();
        // return exercises;
        return _context.Exercises.Select(u => ExerciseMapper.ToExerciseDto(u)).ToList();
    }
    
    // public void Add(ExerciseDto exerciseDto)
    // {
    //     Exercises exercise = new Exercises()
    //     {
    //         Description = exerciseDto.Description,
    //         Type = exerciseDto.Type
    //     };
    //     
    //     _context.Exercises.Add(exercise);
    //      _context.SaveChanges();
    // }
    
    public async Task Add(ExerciseDto exerciseDto)
    {
        Exercises exercise = new Exercises()
        {
           Description = exerciseDto.Description,
           Type = exerciseDto.Type
        };
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Exercises> getExerciseByIdAsync(int Id)
    {
        var exercise = await _context.Exercises.FindAsync(Id);
        return exercise;
    }
    
    public ExerciseDto getExerciseById(int? Id)
    {
        var exercise = _context.Exercises.FirstOrDefault(u => u.Id == Id);
        ExerciseDto ExerciseDto = new ExerciseDto();

        if (exercise != null)
        {
            ExerciseDto.Description = exercise.Description;
            ExerciseDto.Type = exercise.Type;
        }

        ExerciseDto.Exists = exercise != null;
        return ExerciseDto;
    }
    
    public void UpdateExercise(int? id, ExerciseDto exercise)
    {
        Exercises exerciseToUpdate = _context.Exercises.FirstOrDefault(x => x.Id == id);

        if (exerciseToUpdate != null)
        {    
            exerciseToUpdate.Description = exercise.Description;
            exerciseToUpdate.Type = exercise.Type;
            _context.Exercises.Update(exerciseToUpdate);
            _context.SaveChanges();

        }
        else
        {
            throw new Exception($"User with id {id} not found!");
        }
    }
    
    public void DeleteExercise(int id)
    {
        var existingExercise = _context.Exercises.Find(id);
        if (existingExercise != null)
        {
            _context.Exercises.Remove(existingExercise);
            _context.SaveChanges();
        }
    }
}