using System.Collections.Immutable;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.Commands.WorkoutPlanSchemaAdd;
using WorkoutPartner.Domain.DTO.Queries.WorkoutPlanSchemaSearch;

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

    internal static IImmutableList<WorkoutPlanSchemaSearchItemResponseModel> MapFromEntities(
        IEnumerable<WorkoutPlanSchema> entities)
    {
        return entities.Select(e =>
            new WorkoutPlanSchemaSearchItemResponseModel(
                e.Id, 
                e.Name, 
                e.Description, 
                e.CreatedAt
                )
        ).ToImmutableList();
    }
}