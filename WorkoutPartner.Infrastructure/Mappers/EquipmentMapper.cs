using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.EquipmentAdd;

namespace WorkoutPartner.Infrastructure.Mappers;

public static class EquipmentMapper
{
    public static Equipment MapToEntity(EquipmentAddRequest request, DateTime createdAt, string ownerId)
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