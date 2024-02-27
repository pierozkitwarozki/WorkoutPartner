using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Application.Services;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.EquipmentAdd;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers;

public class EquipmentAddCommandHandler(
    IEquipmentRepository equipmentRepository,
    IDateTimeService dateTimeService)
    : IRequestHandler<EquipmentAddCommand, Result<EquipmentAddResponse>>
{
    public async Task<Result<EquipmentAddResponse>> Handle(EquipmentAddCommand request, CancellationToken cancellationToken)
    {
        var entity = EquipmentMapper.MapToEntity(
            request.Request,
            dateTimeService.Now(),
            request.UserId!);
        
        await equipmentRepository.AddAsync(entity);
        await equipmentRepository.SaveChangesAsync();

        return Result<EquipmentAddResponse>.Success(
            new EquipmentAddResponse(entity.Id, entity.Name, entity.Description));
    }
}