using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var requestGuid = Guid.NewGuid().ToString();
            _logger.LogInformation($"{DateTime.Now:s} - Request {requestGuid} - {context.Request.Method} - {context.Request.Path}");

            try
            {
                await _next.Invoke(context);
                _logger.LogInformation($"{DateTime.Now:s} - Reponse {requestGuid} - {context.Response.StatusCode}. Elapsed time: {stopwatch.Elapsed}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now:s} - Response {requestGuid} - {context.Response.StatusCode} - {ex.Message}");
                throw;
            }
        }
    }
}
