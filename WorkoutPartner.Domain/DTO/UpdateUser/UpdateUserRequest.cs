namespace WorkoutPartner.Domain.DTO.UpdateUser;

public record UpdateUserRequest(double? Weight, int? Height, string? UserName);