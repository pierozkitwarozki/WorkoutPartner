using Microsoft.AspNetCore.Identity;
using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Domain.Database.Models;

public class ApplicationUser : IdentityUser
{
    public double? Weight { get; set; }
    public int? Height { get; set; } 
    public WeightUnit? WeightUnit { get; set; }
    public SexType? Sex { get; set; }
    public ICollection<ExerciseSchema>? ExerciseSchemas { get; set; }
    public ICollection<WorkoutPlanSchema>? WorkoutPlanSchemas { get; set; }
    public ICollection<WorkoutRecord>? WorkoutRecords { get; set; }
}