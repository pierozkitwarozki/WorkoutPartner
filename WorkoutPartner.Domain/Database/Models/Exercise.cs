using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing exercise base info
/// </summary>
public class Exercise : BaseEntity
{
    /// <summary>
    /// Exercise name
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Optional: ExerciseUrl, eg. YouTube video or something
    /// </summary>
    public string? Url { get; set; }
    /// <summary>
    /// One of exercise types
    /// </summary>
    public required ExerciseType Type { get; set; }
    /// <summary>
    /// Optional: Foreign key for equipment needed for exercise
    /// </summary>
    public Guid? EquipmentId { get; set; }
    public Equipment? Equipment { get; set; }
    public ICollection<ExerciseSchema>? ExerciseSchemas { get; set; }
}