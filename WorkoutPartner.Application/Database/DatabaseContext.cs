using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.Application.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Exercise>()
            .HasOne(e => e.Owner)
            .WithMany(e => e.Exercises)
            .HasForeignKey(e => e.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Equipment>()
            .HasOne(e => e.Owner)
            .WithMany(e => e.Equipments)
            .HasForeignKey(e => e.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseEquipment>()
            .HasOne(e => e.Equipment)
            .WithMany(e => e.ExerciseEquipments)
            .HasForeignKey(e => e.EquipmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseEquipment>()
            .HasOne(e => e.Exercise)
            .WithMany(e => e.ExerciseEquipments)
            .HasForeignKey(e => e.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseSchema>()
            .HasOne(e => e.User)
            .WithMany(e => e.ExerciseSchemas)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseSchema>()
            .HasOne(e => e.Exercise)
            .WithMany(e => e.ExerciseSchemas)
            .HasForeignKey(e => e.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseRecord>()
            .HasOne(e => e.ExerciseSchema)
            .WithMany(e => e.ExerciseRecords)
            .HasForeignKey(e => e.ExerciseSchemaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseRecordWorkoutRecord>()
            .HasOne(e => e.ExerciseRecord)
            .WithMany(e => e.ExerciseRecordWorkoutRecords)
            .HasForeignKey(e => e.ExerciseRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseRecordWorkoutRecord>()
            .HasOne(e => e.WorkoutRecord)
            .WithMany(e => e.ExerciseRecordWorkoutRecords)
            .HasForeignKey(e => e.WorkoutRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseSchemaWorkoutPlanSchema>()
            .HasOne(e => e.ExerciseSchema)
            .WithMany(e => e.ExerciseSchemaWorkoutPlanSchemas)
            .HasForeignKey(e => e.ExerciseSchemaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ExerciseSchemaWorkoutPlanSchema>() 
            .HasOne(e => e.WorkoutPlanSchema)
            .WithMany(e => e.ExerciseSchemaWorkoutPlanSchemas)
            .HasForeignKey(e => e.WorkoutPlanSchemaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<WorkoutPlanSchema>()
            .HasOne(e => e.User)
            .WithMany(e => e.WorkoutPlanSchemas)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<WorkoutRecord>()
            .HasOne(e => e.User)
            .WithMany(e => e.WorkoutRecords)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}