using System.Text.RegularExpressions;

namespace WorkoutPartner.Infrastructure.Constans;

public static partial class RegularExpressions
{
    private const string CultureName = "en-US";
    private const string WeightRegExString = @"(\d+)(\D+)";
    private const string FreeWeightMachineWeightExerciseRegExString =
        @"((\d{1,3}x)?(\d{1,3}|M)(#\d{1,4}(kg|lbs))?,?)+";
    
    [GeneratedRegex(FreeWeightMachineWeightExerciseRegExString, RegexOptions.IgnoreCase, CultureName)]
    public static partial Regex FreeWeightMachineWeightExerciseRegEx();
    
    [GeneratedRegex(WeightRegExString, RegexOptions.IgnoreCase, CultureName)]
    public static partial Regex WeightRegEx();
}

