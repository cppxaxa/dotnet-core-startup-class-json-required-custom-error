using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AzWebApp1
{
    public class ReformatValidationProblemAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // OData 4.0 format.
            if (context.Result is BadRequestObjectResult badRequestObjectResult
                && badRequestObjectResult.Value is ValidationProblemDetails validationProblemDetails)
            {
                var errorMessages = new List<object>();

                foreach (var error in validationProblemDetails.Errors)
                {
                    foreach (var messageValue in error.Value)
                    {
                        errorMessages.Add(new
                        {
                            message = messageValue,
                            target = error.Key
                        });
                    }
                }

                var errorResult = new
                {
                    message = validationProblemDetails.Title,
                    details = errorMessages
                };

                context.Result = new BadRequestObjectResult(errorResult);
            }

            base.OnResultExecuting(context);
        }
    }
}
