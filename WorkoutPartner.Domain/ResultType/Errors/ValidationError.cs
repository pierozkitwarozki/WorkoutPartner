using System.Text;
using WorkoutPartner.Domain.ResultType.Errors.Codes;

namespace WorkoutPartner.Domain.ResultType.Errors;

public class ValidationError(string type, string description) : ResultError(type, description)
{
    public static ResultError New(IEnumerable<string> errors)
    {
        var sb = new StringBuilder();
        sb.AppendJoin("\n", errors);
        
        return new ValidationError(
            ValidationErrorCodes.GeneralValidation, 
            sb.ToString()
            );
    }
    
    public static ResultError New(string type, string error)
    {
        return new ValidationError(type, error);
    }
}