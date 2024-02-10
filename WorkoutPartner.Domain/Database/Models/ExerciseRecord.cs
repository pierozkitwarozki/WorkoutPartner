namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing actual exercise record
/// </summary>
public class ExerciseRecord : BaseEntity
{
    /// <summary>
    /// Foreign key for exercise schema
    /// </summary>
    public Guid ExerciseSchemaId { get; set; }
    /// <summary>
    /// Exercise schema used in record
    /// </summary>
    public ExerciseSchema? ExerciseSchema { get; set; }
    /// <summary>
    /// Schema with actual filled values on training
    /// </summary>
    public required string FilledSchema { get; set; }
    public ICollection<ExerciseRecordWorkoutRecord>? ExerciseRecordWorkoutRecords { get; set; }
}