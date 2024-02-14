using WorkoutPartner.Domain.DTO.Paging;

namespace WorkoutPartner.Domain.DTO.ExerciseSearch;

public record ExerciseSearchRequest(int PageNumber, int PageSize, string? Phrase) 
    : PageRequest(PageNumber, PageSize);
