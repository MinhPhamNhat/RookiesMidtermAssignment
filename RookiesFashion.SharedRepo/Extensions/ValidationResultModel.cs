using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using RookiesFashion.SharedRepo.Extensions;
// https://docs.microsoft.com/en-us/answers/questions/620570/net-core-web-api-model-validation-error-response-t.html
namespace RookiesFashion.SharedRepo.Extension;
    public class ValidationResultModel
{
    public string Message { get; }
    public List<ValidationError> Errors { get; }
    public bool IsValidation { get; set; } = false;
    public ValidationResultModel(ModelStateDictionary modelState)
    {
        Message = "Validation Failed (1)";
        Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, modelState[key].RawValue, x.ErrorMessage)))
                .ToList();
        IsValidation = true;
    }

    public ValidationResultModel(List<ValidationError> errors)
    {
        Message = "Validation Failed (2)";
        Errors = errors;
        IsValidation = true;
    }

    public ValidationResultModel(ValidationError error)
    {
        Message = "Validation Failed (3)";
        Errors = new List<ValidationError>() { error };
        IsValidation = true;
    }
}