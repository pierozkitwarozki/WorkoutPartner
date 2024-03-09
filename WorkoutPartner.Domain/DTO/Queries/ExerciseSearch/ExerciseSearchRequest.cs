using WorkoutPartner.Domain.DTO.Queries.Paging;

namespace WorkoutPartner.Domain.DTO.Queries.ExerciseSearch;

public record ExerciseSearchRequest(int PageNumber, int PageSize, string? Phrase) 
    : PageRequest(PageNumber, PageSize);
