using WorkoutPartner.Domain.DTO.ExerciseAdd;
using WorkoutPartner.Domain.DTO.Paging;

namespace WorkoutPartner.Domain.DTO.ExerciseSearch;

public record ExerciseSearchResponse(bool ContainsMore, IEnumerable<ExerciseAddResponse> Exercises) 
    : PageResponse(ContainsMore);