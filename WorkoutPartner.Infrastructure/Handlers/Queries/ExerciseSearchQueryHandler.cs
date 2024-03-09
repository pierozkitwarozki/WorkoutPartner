using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutPartner.Application.Queries;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.DTO.Queries.ExerciseSearch;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers.Queries;

public class ExerciseSearchQueryHandler(IExerciseRepository exerciseRepository)
    : IRequestHandler<ExerciseSearchQuery, Result<ExerciseSearchResponse>>
{
    public async Task<Result<ExerciseSearchResponse>> Handle(ExerciseSearchQuery request, CancellationToken cancellationToken)
    {
        var searchPhrase = request.Request.Phrase?.ToLower() ?? string.Empty;
        
        var searchResult = exerciseRepository
            .WherePaged(request.Request,
                exercise
                    => exercise.Name.ToLower().Contains(searchPhrase));

        var exercises = await searchResult
            .Item1
            .Select(exercise => ExerciseMapper.MapFromEntity(exercise))
            .ToListAsync(cancellationToken);

        return Result<ExerciseSearchResponse>.Success(new ExerciseSearchResponse(searchResult.Item2, exercises));
    }
}