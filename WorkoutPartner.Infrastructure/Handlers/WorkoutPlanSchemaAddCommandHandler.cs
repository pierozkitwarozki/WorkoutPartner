using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Application.Services;
using WorkoutPartner.Domain.DTO.WorkoutPlanSchemaAdd;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers;

public class WorkoutPlanSchemaAddCommandHandler(
    IDateTimeService dateTimeService,
    IWorkoutPlanSchemaRepository workoutPlanSchemaRepository,
    IExerciseSchemaWorkoutPlanSchemaRepository exerciseSchemaWorkoutPlanSchemaRepository
    )
    : IRequestHandler<WorkoutPlanSchemaAddCommand, Result<WorkoutPlanSchemaAddResponse>>
{
    public async Task<Result<WorkoutPlanSchemaAddResponse>> Handle(WorkoutPlanSchemaAddCommand request, CancellationToken cancellationToken)
    {
        var workoutPlanSchemaEntity = WorkoutPlanSchemaMapper.MapToEntity(
            request.Request,
            request.UserId!,
            dateTimeService.Now()
            );

        await workoutPlanSchemaRepository.AddAsync(workoutPlanSchemaEntity);

        var exerciseSchemaWorkoutPlanSchemaEntities = 
            ExerciseSchemaWorkoutPlanSchemaMapper.MapToEntities(
                request.Request, 
                workoutPlanSchemaEntity.Id, 
                dateTimeService.Now()
                );

        await exerciseSchemaWorkoutPlanSchemaRepository.AddRangeAsync(exerciseSchemaWorkoutPlanSchemaEntities);
        await workoutPlanSchemaRepository.SaveChangesAsync();

        return Result<WorkoutPlanSchemaAddResponse>.Success(
            new WorkoutPlanSchemaAddResponse(workoutPlanSchemaEntity.Id));
    }
}