namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing workout plan schema
/// </summary>
public class WorkoutPlanSchema : BaseEntity
{
    /// <summary>
    /// Foreign key for user that created a plan
    /// </summary>
    public required string UserId { get; set; }
    /// <summary>
    /// User that created a plan
    /// </summary>
    public ApplicationUser? User { get; set; }
    /// <summary>
    /// Name of the workout plan
    /// </summary>
    public required string Name { get; set; }
    public ICollection<ExerciseSchemaWorkoutPlanSchema>? ExerciseSchemaWorkoutPlanSchemas { get; set; }
}