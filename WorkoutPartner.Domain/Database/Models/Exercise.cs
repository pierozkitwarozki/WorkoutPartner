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
    /// Collection of equipment needed
    /// </summary>
    public virtual ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }
    public virtual ICollection<ExerciseSchema>? ExerciseSchemas { get; set; }
}