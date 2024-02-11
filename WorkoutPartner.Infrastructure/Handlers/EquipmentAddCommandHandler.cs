using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Application.Services.Interfaces;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.EquipmentAdd;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Infrastructure.Handlers;

public class EquipmentAddCommandHandler(
    IEquipmentRepository equipmentRepository,
    IDateTimeService dateTimeService)
    : IRequestHandler<EquipmentAddCommand, Result<EquipmentAddResponse>>
{
    public async Task<Result<EquipmentAddResponse>> Handle(EquipmentAddCommand request, CancellationToken cancellationToken)
    {
        var entity = MapToEntity(request.Request);
        
        await equipmentRepository.AddAsync(entity);
        await equipmentRepository.SaveChangesAsync();

        return Result<EquipmentAddResponse>.Success(
            new EquipmentAddResponse(entity.Id, entity.Name, entity.Description));
    }

    private Equipment MapToEntity(EquipmentAddRequest request)
    {
        return new Equipment
        {
            Id = Guid.NewGuid(),
            CreatedAt = dateTimeService.Now(),
            Name = request.Name,
            Description = request.Description
        };
    }
}