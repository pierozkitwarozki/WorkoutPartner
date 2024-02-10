using System.Text;

namespace WorkoutPartner.Domain.ResultType.Errors;

public class ValidationError(string type, string description) : ResultError(type, description)
{
    public static ResultError New(IEnumerable<string> errors)
    {
        var sb = new StringBuilder();
        sb.AppendJoin("\n", errors);
        
        return new ValidationError(
            nameof(ValidationError), 
            sb.ToString()
            );
    }
}