
using Blazornetrom.Entites;
using Microsoft.EntityFrameworkCore;
using Netrom.Entities;

namespace Blazornetrom.Context
{
    public class SmartWorkoutContext: DbContext
    {
        public SmartWorkoutContext(DbContextOptions<SmartWorkoutContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Exercises> Exercises { get; set;}

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<ExerciseLog> ExercisesLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(u => u.Workouts)
                .HasForeignKey(w => w.UserId)
                .HasConstraintName("FK_Worksouts_Users");

            modelBuilder.Entity<ExerciseLog>()
                .HasOne(el => el.Exercises)
                .WithMany(e => e.ExercisesLogs)
                .HasForeignKey(el => el.ExerciseId)
                .HasConstraintName("FK_ExercicesLogs_Exercices");

            modelBuilder.Entity<ExerciseLog>()
                .HasOne(el => el.Workouts)
                .WithMany(w => w.ExercisesLogs)
                .HasForeignKey(el => el.WorkoutId)
                .HasConstraintName("FK_ExercicesLogs_Workouts");

            base.OnModelCreating(modelBuilder);

        }
    }
}