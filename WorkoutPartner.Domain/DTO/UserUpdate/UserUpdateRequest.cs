namespace WorkoutPartner.Domain.DTO.UserUpdate;

public record UserUpdateRequest(double? Weight, int? Height, string? UserName);