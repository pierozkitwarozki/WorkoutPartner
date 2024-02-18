namespace WorkoutPartner.Domain.Models;

/// <summary>
/// Records that represent a free-weight/machine-weight workout
/// </summary>
/// <param name="SetNumber">Set order</param>
/// <param name="Reps">Number of reps</param>
/// <param name="Weight">Optional: weight</param>
/// <param name="Unit">Optional: unit</param>
public record WeightWorkoutSet(int SetNumber, string Reps, int? Weight, string? Unit);