using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Equipment>()
            .HasKey(e => e.Id);

        builder.Entity<Exercise>()
            .HasOne(e => e.Equipment)
            .WithMany(e => e.Exercises)
            .HasForeignKey(e => e.EquipmentId);

        builder.Entity<ExerciseSchema>()
            .HasOne(e => e.User)
            .WithMany(e => e.ExerciseSchemas)
            .HasForeignKey(e => e.UserId);

        builder.Entity<ExerciseSchema>()
            .HasOne(e => e.Exercise)
            .WithMany(e => e.ExerciseSchemas)
            .HasForeignKey(e => e.ExerciseId);

        builder.Entity<ExerciseRecord>()
            .HasOne(e => e.ExerciseSchema)
            .WithMany(e => e.ExerciseRecords)
            .HasForeignKey(e => e.ExerciseSchemaId);

        builder.Entity<ExerciseRecordWorkoutRecord>()
            .HasOne(e => e.ExerciseRecord)
            .WithMany(e => e.ExerciseRecordWorkoutRecords)
            .HasForeignKey(e => e.ExerciseRecordId);

        builder.Entity<ExerciseRecordWorkoutRecord>()
            .HasOne(e => e.WorkoutRecord)
            .WithMany(e => e.ExerciseRecordWorkoutRecords)
            .HasForeignKey(e => e.WorkoutRecordId);

        builder.Entity<ExerciseSchemaWorkoutPlanSchema>()
            .HasOne(e => e.ExerciseSchema)
            .WithMany(e => e.ExerciseSchemaWorkoutPlanSchemas)
            .HasForeignKey(e => e.ExerciseSchemaId);

        builder.Entity<ExerciseSchemaWorkoutPlanSchema>() 
            .HasOne(e => e.WorkoutPlanSchema)
            .WithMany(e => e.ExerciseSchemaWorkoutPlanSchemas)
            .HasForeignKey(e => e.WorkoutPlanSchemaId);

        builder.Entity<WorkoutPlanSchema>()
            .HasOne(e => e.User)
            .WithMany(e => e.WorkoutPlanSchemas)
            .HasForeignKey(e => e.UserId);
        
        builder.Entity<WorkoutRecord>()
            .HasOne(e => e.User)
            .WithMany(e => e.WorkoutRecords)
            .HasForeignKey(e => e.UserId);

    }
}