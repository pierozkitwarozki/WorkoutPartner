namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing exercise schema
/// It can be used later on for creating workout plans
/// </summary>
public class ExerciseSchema : BaseEntity
{
    /// <summary>
    /// Foreign key for user that created the schema
    /// </summary>
    public required string UserId { get; set; }
    /// <summary>
    /// User that created the schema
    /// </summary>
    public ApplicationUser? User { get; set; }
    /// <summary>
    /// Exercise schema. To be figured out.
    /// </summary>
    public required string Schema { get; set; }
    /// <summary>
    /// Foreign key for exercise
    /// </summary>
    public required Guid ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }
    public ICollection<ExerciseRecord>? ExerciseRecords { get; set; }
    public ICollection<ExerciseSchemaWorkoutPlanSchema>? ExerciseSchemaWorkoutPlanSchemas { get; set; }
}