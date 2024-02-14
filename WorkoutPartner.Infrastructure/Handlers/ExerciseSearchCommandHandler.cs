using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Domain.DTO.ExerciseSearch;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers;

public class ExerciseSearchCommandHandler(IExerciseRepository exerciseRepository)
    : IRequestHandler<ExerciseSearchCommand, Result<ExerciseSearchResponse>>
{
    public async Task<Result<ExerciseSearchResponse>> Handle(ExerciseSearchCommand request, CancellationToken cancellationToken)
    {
        var searchPhrase = request.Request.Phrase?.ToLower() ?? string.Empty;
        
        var searchResult = exerciseRepository
            .WherePaged(request.Request,
                exercise
                    => exercise.Name.ToLower().Contains(searchPhrase));

        var exercises = await searchResult
            .Item1
            .Select(exercise => ExerciseMapper.MapFromExerciseToExerciseAddResponse(exercise))
            .ToListAsync(cancellationToken);

        return Result<ExerciseSearchResponse>.Success(new ExerciseSearchResponse(searchResult.Item2, exercises));
    }
}