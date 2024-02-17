using WorkoutPartner.Domain.Models;
using WorkoutPartner.Infrastructure.Constans;

namespace WorkoutPartner.Infrastructure.Converters;

public static class WeightWorkoutConverter
{
    public static IEnumerable<WeightWorkout?> Convert(string mainSchema)
    {
        var schemas = mainSchema.Split(',');
        foreach (var schema in schemas)
        {
            var parsedWorkout = InnerConvertWeightSchema(schema);
            if (parsedWorkout is null)
            {
                continue;
            }
            yield return parsedWorkout;
        }
    }

    private static WeightWorkout? InnerConvertWeightSchema(string schema)
    {
        if (!IsFirstCharValid(schema))
        {
            return null;
        }
        
        var match = RegularExpressions.FreeWeightMachineWeightExerciseRegEx().Match(schema);

        if (!match.Success)
        {
            return null;
        }
        
        var sets = string.IsNullOrWhiteSpace(match.Groups[2].Value)
            ? 1 : int.Parse(match.Groups[2].Value.Replace("x", ""));
            
        var reps = match.Groups[3].Value;
        var weightPair = InnerTryConvertWeight(match.Groups[4].Value);

        return new WeightWorkout(sets, reps, weightPair?.Item1, weightPair?.Item2);
    }

    private static (int?, string?)? InnerTryConvertWeight(string weight)
    {
        var fixedWeight = weight.Replace("#", "");
        var match = RegularExpressions.WeightRegEx().Match(fixedWeight);

        if (!match.Success)
        {
            return null;
        }
        var number = int.Parse(match.Groups[1].Value);
        var unit = match.Groups[2].Value;

        return (number, unit);
    }
    
    private static bool IsFirstCharValid(string schema)
    {
        if (!string.IsNullOrWhiteSpace(schema))
        {
            return false;
        }

        var firstChar = schema[0];

        var isValid = char.IsDigit(firstChar)
                      || firstChar == 'm'
                      || firstChar == 'M';

        return isValid;
    }
}