using Microsoft.EntityFrameworkCore;

namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Entity to handle many-to-many relationship
/// between ExerciseRecord and WorkoutRecord
/// </summary>
[PrimaryKey(nameof(ExerciseRecordId), nameof(WorkoutRecordId))]
public class ExerciseRecordWorkoutRecord
{
    /// <summary>
    /// Foreign key for exercise record
    /// </summary>
    public required Guid ExerciseRecordId { get; set; }
    public ExerciseRecord? ExerciseRecord { get; set; }

    /// <summary>
    /// Foreign key for workout record
    /// </summary>
    public required Guid WorkoutRecordId { get; set; }
    public WorkoutRecord? WorkoutRecord { get; set; }

    /// <summary>
    /// Exercise order in workout
    /// </summary>
    public required int ExerciseOrder { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
}