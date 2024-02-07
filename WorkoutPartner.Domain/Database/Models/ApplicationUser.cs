using Microsoft.AspNetCore.Identity;

namespace WorkoutPartner.Domain.Database.Models;

public class ApplicationUser : IdentityUser
{
    public double? Weight { get; set; }
    public int? Height { get; set; } 
}