using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Infrastructure.Converters;

public static class BodyPartsConverter
{
    public static BodyParts ConvertToBodyParts(this IEnumerable<int>? bodyParts)
    {
        var result = BodyParts.None;
        
        if (bodyParts is null)
        {
            return result;
        }
        
        foreach (var bodyPart in bodyParts)
        {
            if (Enum.IsDefined(typeof(BodyParts), bodyPart))
            {
                result |= (BodyParts)bodyPart;
            }
        }

        return result;
    }
}