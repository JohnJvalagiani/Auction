using Auction.Api.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var errors in errorsInModelState)
                {

                    foreach (var suberror in errors.Value)
                    {

                        var errorModel = new ErrorModel()
                        {
                            FieldName = errors.Key,
                            Message = suberror
                        };

                        errorResponse.Errors.Add(errorModel);


                    }

                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;

            }
            await next();

        }
    }
}
