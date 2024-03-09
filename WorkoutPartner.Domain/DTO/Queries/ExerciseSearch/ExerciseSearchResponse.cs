using WorkoutPartner.Domain.DTO.Commands.ExerciseAdd;
using WorkoutPartner.Domain.DTO.Queries.Paging;

namespace WorkoutPartner.Domain.DTO.Queries.ExerciseSearch;

public record ExerciseSearchResponse(bool ContainsMore, IEnumerable<ExerciseAddResponse> Exercises) 
    : PageResponse(ContainsMore);