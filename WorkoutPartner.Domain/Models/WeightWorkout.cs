namespace WorkoutPartner.Domain.Models;

/// <summary>
/// Records that represent a free-weight/machine-weight workout
/// </summary>
/// <param name="Sets">Number of sets (if not specified - 1)</param>
/// <param name="Reps">Number of reps</param>
/// <param name="Weight">Optional: weight</param>
/// <param name="Unit">Optional: unit</param>
public record WeightWorkout(int Sets, string Reps, int? Weight, string? Unit);