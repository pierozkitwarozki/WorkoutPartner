using Microsoft.EntityFrameworkCore;

namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Entity to handle many-to-many relationship
/// between ExerciseRecord and WorkoutRecord
/// </summary>
[PrimaryKey(nameof(ExerciseId), nameof(EquipmentId))]
public class ExerciseEquipment
{
    /// <summary>
    /// Foreign key for exercise
    /// </summary>
    public Guid ExerciseId { get; set; }
    public virtual Exercise? Exercise { get; set; }
    /// <summary>
    /// Foreign key for equipment
    /// </summary>
    public Guid EquipmentId { get; set; }
    public virtual Equipment? Equipment { get; set; }
    public DateTime CreatedAt { get; set; }
}