using System.Collections.Immutable;
using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Application.Services.Interfaces;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.ExerciseAdd;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers;

public class ExerciseAddCommandHandler(
    IExerciseRepository exerciseRepository,
    IEquipmentRepository equipmentRepository,
    IExerciseEquipmentRepository exerciseEquipmentRepository,
    IDateTimeService dateTimeService)
    : IRequestHandler<ExerciseAddCommand, Result<ExerciseAddResponse>>
{
    public async Task<Result<ExerciseAddResponse>> Handle(ExerciseAddCommand request, CancellationToken cancellationToken)
    {
        var entity = ExerciseMapper.MapToEntity(
            request.Request, 
            dateTimeService.Now(),
            request.UserId!);

        await exerciseRepository.AddAsync(entity);

        await AddEquipments(request.Request.EquipmentIds?.ToImmutableList(), entity.Id);
        
        await exerciseRepository.SaveChangesAsync();

        var response = ExerciseMapper.MapFromEntity(entity);

        return Result<ExerciseAddResponse>.Success(response);
    }

    private async Task AddEquipments(IReadOnlyList<Guid>? equipmentIds, Guid exerciseId)
    {
        if (equipmentIds is null || !equipmentIds.Any())
        {
            return;
        }
        
        foreach (var id in equipmentIds.Distinct())
        {
            var equipment = await equipmentRepository.GetByIdAsync(id);
            if (equipment is not null)
            {
                await exerciseEquipmentRepository.AddAsync(new ExerciseEquipment
                {
                    ExerciseId = exerciseId,
                    EquipmentId = id
                });
            }
        }
    }
}