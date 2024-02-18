using WorkoutPartner.Domain.Models;
using WorkoutPartner.Infrastructure.Constans;

namespace WorkoutPartner.Infrastructure.Converters;

public static class WeightWorkoutConverter
{
    public static IEnumerable<WeightWorkout> ConvertExercise(string mainSchema)
    {
        var schemas = mainSchema.Split(',');
        var setNumber = 1;
        var exercises = new List<WeightWorkout>();
        foreach (var schema in schemas)
        {
            var parsedWorkout = InnerConvertWeightSchema(schema, ref setNumber);
            exercises.AddRange(parsedWorkout);
        }

        return exercises;
    }

    private static IEnumerable<WeightWorkout> InnerConvertWeightSchema(string schema, ref int setNumber)
    {
        if (!IsFirstCharValid(schema))
        {
            return Enumerable.Empty<WeightWorkout>();
        }
        
        var match = RegularExpressions.FreeWeightMachineWeightExerciseRegEx().Match(schema);

        if (!match.Success)
        {
            return Enumerable.Empty<WeightWorkout>();
        }

        var workouts = new List<WeightWorkout>();
        
        var sets = string.IsNullOrWhiteSpace(match.Groups[2].Value)
            ? 1 : int.Parse(match.Groups[2].Value.Replace("x", ""));
        
        var reps = match.Groups[3].Value;
        var weightPair = InnerTryConvertWeight(match.Groups[4].Value);

        for (var i=0; i < sets; i++)
        {
            var workout = new WeightWorkout(setNumber, reps, weightPair?.Item1, weightPair?.Item2);
            workouts.Add(workout);
            setNumber++;
        }

        return workouts;
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
        if (string.IsNullOrWhiteSpace(schema))
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