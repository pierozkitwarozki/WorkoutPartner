using System.Security.Claims;

namespace WorkoutPartner.Application.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserNameIdentifier(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
}