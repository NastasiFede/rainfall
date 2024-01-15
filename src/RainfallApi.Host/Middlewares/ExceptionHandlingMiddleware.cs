using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RainfallApi.Infrastructure.Exceptions;
using System.Net;
using RainfallApi.Application.Models;
using FluentValidation;

namespace RainfallApi.Host.Middlewares;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private static readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
    };

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            await WriteResponse(context, HttpStatusCode.BadRequest, exception);
        }
        catch (ItemNotFoundException exception)
        {
            await WriteResponse(context, HttpStatusCode.NotFound, exception);
        }
        catch (ApplicationException exception)
        {
            await WriteResponse(context, HttpStatusCode.InternalServerError, exception);
        }
        catch (Exception exception)
        {
            await WriteResponse(context, HttpStatusCode.InternalServerError, exception);
        }
    }

    private Task WriteResponse(HttpContext context, HttpStatusCode statusCode, Exception exception)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var errorResult = new ErrorResponse
        {
            Message = exception.Message
        };

        if (exception is ValidationException validationException)
        {
            errorResult.Detail = validationException.Errors.Select(e => new ErrorDetail
            {
                Message = e.ErrorMessage,
                PropertyName = e.PropertyName
            }).ToList();
        }

        // Convert errorResult to JObject
        var jsonObject = JObject.FromObject(errorResult, JsonSerializer.Create(_jsonSerializerSettings));

        if (statusCode == HttpStatusCode.BadRequest)
        {
            // Remove the 'type' property
            jsonObject.Remove("type");
        }

        // Convert the JObject back to a string without the 'type' property
        var jsonContent = jsonObject.ToString();

        return context.Response.WriteAsync(jsonContent);
    }
}