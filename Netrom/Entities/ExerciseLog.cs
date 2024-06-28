
using Netrom.Entities;

namespace Blazornetrom.Entites
{
    public class ExerciseLog
    {
        public int Id {  get; set; }
        public int Reps {  get; set; }
        public int Duration { get; set; }
        public int ExerciseId { get; set; }
        public Exercises Exercises { get; set; }

        public int WorkoutId {  get; set; }
        public Workout Workouts { get; set; }  
        
    }
}