using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.WorkoutPlanSchemaAdd;

namespace WorkoutPartner.Infrastructure.Mappers;

internal static class WorkoutPlanSchemaMapper
{
    internal static WorkoutPlanSchema MapToEntity(WorkoutPlanSchemaAddRequest request, string userId, DateTime createdAt)
    {
        return new WorkoutPlanSchema
        {
            UserId = userId,
            CreatedAt = createdAt,
            Description = request.Description,
            Name = request.Name,
            Id = Guid.NewGuid()
        };
    }
}