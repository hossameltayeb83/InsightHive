﻿using InsightHive.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace InsightHive.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }

        private Task HandleException(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
            string result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.ValdationErrors);
                    break;
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case Exception:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }


            return httpContext.Response.WriteAsync(result);
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
