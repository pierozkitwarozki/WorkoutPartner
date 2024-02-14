using Microsoft.EntityFrameworkCore;

namespace WorkoutPartner.Domain.Database.Models;

[PrimaryKey(nameof(Id))]
public abstract class BaseEntity
{
    /// <summary>
    /// Entity primary key
    /// </summary>
    public required Guid Id { get; init; }
    /// <summary>
    /// Optional: description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Created DateTime
    /// </summary>
    public required DateTime CreatedAt { get; init; }
}