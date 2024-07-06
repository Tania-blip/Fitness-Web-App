using Netrom.Components.Models;
using Netrom.Entities;

namespace Netrom;

public class ExerciseMapper
{
    public static Exercises ToExercise(ExerciseDto exerciseDto)
    {
        return new Exercises()
        {
            Description = exerciseDto.Description,
            Type = exerciseDto.Type
        };
    }
    
    public static ExerciseDto ToExerciseDto(Exercises exercise)
    {
        return new ExerciseDto()
        {
            Id =  exercise.Id,
            Description = exercise.Description,
            Type = exercise.Type
        };
    }
}