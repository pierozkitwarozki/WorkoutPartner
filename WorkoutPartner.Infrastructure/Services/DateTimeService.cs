using WorkoutPartner.Application.Services;

namespace WorkoutPartner.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now() => DateTime.UtcNow;
}