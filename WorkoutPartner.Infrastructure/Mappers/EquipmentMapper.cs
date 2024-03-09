using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.Commands.EquipmentAdd;

namespace WorkoutPartner.Infrastructure.Mappers;

internal static class EquipmentMapper
{
    internal static Equipment MapToEntity(EquipmentAddRequest request, DateTime createdAt, string ownerId)
    {
        return new Equipment
        {
            Id = Guid.NewGuid(),
            CreatedAt = createdAt,
            Name = request.Name,
            Description = request.Description,
            OwnerId = ownerId
        };
    }
}