namespace WorkoutPartner.Domain.Database.Models;

/// <summary>
/// Class representing equipment unit
/// </summary>
public class Equipment : BaseEntity
{
    /// <summary>
    /// Equipment Name
    /// </summary>
    public required string Name { get; set; }
    public ICollection<Exercise>? Exercises { get; set; }
}