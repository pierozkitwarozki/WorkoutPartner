using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutPartner.Application.Queries;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.DTO.Queries.WorkoutPlanSchemaSearch;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers.Queries;

public class WorkoutPlanSchemaSearchQueryHandler(IWorkoutPlanSchemaRepository workoutPlanSchemaRepository)
    : IRequestHandler<WorkoutPlanSchemaSearchQuery, Result<WorkoutPlanSchemaSearchResponse>>
{
    public async Task<Result<WorkoutPlanSchemaSearchResponse>> Handle(WorkoutPlanSchemaSearchQuery request, CancellationToken cancellationToken)
    {
        var searchPhrase = request.Request.Name ?? string.Empty;

        var (baseQuery, containsMore) = workoutPlanSchemaRepository
            .WherePaged(request.Request, schema => 
                schema.Name.ToLower().Contains(searchPhrase)
                && schema.UserId == request.UserId);

        var entities = await baseQuery.ToListAsync(cancellationToken: cancellationToken);

        var orderedSchemas =
            WorkoutPlanSchemaMapper.MapFromEntities(entities)
                .OrderByDescending(x => x.CreatedAt);

        return Result<WorkoutPlanSchemaSearchResponse>.Success(
            new WorkoutPlanSchemaSearchResponse(containsMore, orderedSchemas));
    }
}