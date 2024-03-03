using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing exercise base info
/// </summary>
public class Exercise : BaseEntity
{
    /// <summary>
    /// Foreign key for user that created entity
    /// </summary>
    public string OwnerId { get; set; }
    /// <summary>
    /// Exercise name
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Optional: VideoUrl, eg. YouTube video or something
    /// </summary>
    public string? VideoUrl { get; set; }
    /// <summary>
    /// Optional: Url with additional images
    /// </summary>
    public string? ImageUrl { get; set; }
    /// <summary>
    /// Optional: Body parts used in that exercise
    /// </summary>
    public BodyParts BodyParts { get; set; }
    /// <summary>
    /// One of exercise types
    /// </summary>
    public required ExerciseType Type { get; set; }
    public virtual ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }
    public virtual ICollection<ExerciseSchema>? ExerciseSchemas { get; set; }
    public virtual ApplicationUser Owner { get; set; }
}