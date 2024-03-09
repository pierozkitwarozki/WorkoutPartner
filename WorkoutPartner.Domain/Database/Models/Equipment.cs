namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing equipment unit
/// </summary>
public class Equipment : BaseEntity
{
    /// <summary>
    /// Foreign key for user that created entity
    /// </summary>
    public required string OwnerId { get; init; }
    /// <summary>
    /// Equipment Name
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Collection of equipment needed
    /// </summary>
    public virtual ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }
    public virtual ApplicationUser Owner { get; set; }
}