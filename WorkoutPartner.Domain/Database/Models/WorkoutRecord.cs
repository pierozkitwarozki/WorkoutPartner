namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing actual workout plan record
/// </summary>
public class WorkoutRecord : BaseEntity
{
    /// <summary>
    /// Foreign key for user that created a plan
    /// </summary>
    public required string UserId { get; set; }
    /// <summary>
    /// User that created a plan
    /// </summary>
    public virtual ApplicationUser? User { get; set; }
    /// <summary>
    /// Name of the workout plan
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Workout start
    /// </summary>
    public required DateTime StartDateTime { get; set; }
    /// <summary>
    /// Workout end
    /// </summary>
    public required DateTime EndDateTime { get; set; }
    public virtual ICollection<ExerciseRecordWorkoutRecord>? ExerciseRecordWorkoutRecords { get; set; }
}