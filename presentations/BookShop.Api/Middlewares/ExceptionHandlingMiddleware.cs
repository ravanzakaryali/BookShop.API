using BookShop.Application.DTOs.CommonDtos;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Text.Json;

namespace BookShop.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(SqlException ex)
        {
            ErrorResponse error = await HandleExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            ErrorResponse error = await HandleExceptionAsync(httpContext, ex);
            _logger.LogError(ex, $"Request {httpContext.Request?.Method}: {httpContext.Request?.Path.Value} failed Error: {@error}", error);
        }
    }
    private async Task<ErrorResponse> HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        ErrorResponse reponse = new()
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message,
        };
        var json = JsonSerializer.Serialize(reponse);
        await context.Response.WriteAsync(json);
        return reponse;
    }
}
public static class ExceptionHandlerMiddelwareExtensions
{
    public static IApplicationBuilder UseExceptionMiddelware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
