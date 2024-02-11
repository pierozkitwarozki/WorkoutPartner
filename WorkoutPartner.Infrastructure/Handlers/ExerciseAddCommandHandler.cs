using System.Collections.Immutable;
using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Application.Services.Interfaces;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.ExerciseAdd;
using WorkoutPartner.Domain.ResultType;

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
        var entity = MapToEntity(request.Request);

        await exerciseRepository.AddAsync(entity);

        await AddEquipments(request.Request.EquipmentIds?.ToImmutableList(), entity.Id);
        
        await exerciseRepository.SaveChangesAsync();

        var response = MapToResponse(entity);

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

    private Exercise MapToEntity(ExerciseAddRequest request)
    {
        return new Exercise
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            CreatedAt = dateTimeService.Now(),
            Name = request.Name,
            Type = request.Type,
            Url = request.Url
        };
    }

    private ExerciseAddResponse MapToResponse(Exercise exercise)
    {
        var equipment = exercise.ExerciseEquipments?
            .Select(e 
                => new KeyValuePair<Guid, string>(
                    e.EquipmentId, 
                    e.Equipment?.Name ?? string.Empty
                    ))
            .ToDictionary();
        
        return new ExerciseAddResponse(
            exercise.Id,
            exercise.Name,
            exercise.Description,
            exercise.CreatedAt,
            exercise.Type,
            exercise.Url, 
            equipment
        );

    }
}