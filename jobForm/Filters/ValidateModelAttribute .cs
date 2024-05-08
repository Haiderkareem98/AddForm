using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace jobForm.Filters;

public class ValidationError(string field, int code, string message)
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Field { get; } = (field != string.Empty ? field : null) ?? string.Empty;

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int Code { get; set; } =
        code != 0 ? code : 55; //set the default code to 55. you can remove it or change it to 400.

    public string Message { get; } = message;
}

public class ValidationResultModel
{
    public ValidationResultModel(ModelStateDictionary modelState)
    {
        Message = "Validation Failed";
        Errors = modelState.Keys
            .SelectMany(key =>
                modelState[key]?.Errors.Select(x => new ValidationError(key, 0, x.ErrorMessage)) ??
                Array.Empty<ValidationError>())
            .ToList();
    }

    public string Message { get; }
    public List<ValidationError> Errors { get; }
}

public class ValidationFailedResult : ObjectResult
{
    public ValidationFailedResult(ModelStateDictionary modelState)
        : base(new ValidationResultModel(modelState))
    {
        StatusCode = StatusCodes.Status422UnprocessableEntity; //change the http status code to 422.
    }
}

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext actionContext)
    {
        if (actionContext.ModelState.IsValid == false)
            actionContext.Result = new ValidationFailedResult(actionContext.ModelState);
    }
}