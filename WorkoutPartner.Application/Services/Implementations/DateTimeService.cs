using WorkoutPartner.Application.Services.Interfaces;

namespace WorkoutPartner.Application.Services.Implementations;

public class DateTimeService : IDateTimeService
{
    public DateTimeOffset Now() => DateTimeOffset.UtcNow;
}