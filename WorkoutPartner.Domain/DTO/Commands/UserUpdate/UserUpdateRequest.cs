namespace WorkoutPartner.Domain.DTO.Commands.UserUpdate;

public record UserUpdateRequest(double? Weight, int? Height, string? UserName);