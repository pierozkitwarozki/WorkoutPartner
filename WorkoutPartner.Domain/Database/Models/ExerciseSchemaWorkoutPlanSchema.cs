using Microsoft.EntityFrameworkCore;

namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Entity to handle many-to-many relationship
/// between ExerciseSchema and WorkoutPlanSchema
/// </summary>
[PrimaryKey(nameof(ExerciseSchemaId), nameof(WorkoutPlanSchemaId))]
public class ExerciseSchemaWorkoutPlanSchema
{
    /// <summary>
    /// Foreign key for exercise schema
    /// </summary>
    public required Guid ExerciseSchemaId { get; set; }
    public virtual ExerciseSchema? ExerciseSchema { get; set; }
    
    /// <summary>
    /// Foreign key for workout plan schema
    /// </summary>
    public required Guid WorkoutPlanSchemaId { get; set; }
    public virtual WorkoutPlanSchema? WorkoutPlanSchema { get; set; }
    
    /// <summary>
    /// Exercise order in workout plan
    /// </summary>
    public required int ExerciseOrder { get; set; }
    public required DateTime CreatedAt { get; set; }
}