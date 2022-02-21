using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
// https://docs.microsoft.com/en-us/answers/questions/620570/net-core-web-api-model-validation-error-response-t.html
namespace RookiesFashion.APIService.Helpers
{
     public class ValidationResultModel
     {
         public string Message { get; }
         public List<ValidationError> Errors { get; }
         public ValidationResultModel(ModelStateDictionary modelState)
         {
             Message = "Validation Failed";
             Errors = modelState.Keys
                     .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, modelState[key].RawValue , x.ErrorMessage)))
                     .ToList();
         }

         public ValidationResultModel(List<ValidationError> errors){
             Message = "Validation Failed";
             Errors = errors;
         }

         public ValidationResultModel(ValidationError error){
             Message = "Validation Failed";
             Errors = new List<ValidationError>(){error};
         }
     }
}