using E_Commerce_Application.Errors;
using System.Net;
using System.Text.Json;

namespace E_Commerce_Application.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate mid, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _requestDelegate = mid;
            _logger = logger;
            _env = env;

        }

        public async Task InvokeAsync(HttpContext cxt)
        {
            try
            {
                await _requestDelegate(cxt);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                cxt.Response.ContentType = "application/json";
                cxt.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment() ? new APIException((int)HttpStatusCode.InternalServerError, ex.Message,
                    ex.StackTrace.ToString()) : new APIException((int)HttpStatusCode.InternalServerError);
                var json = JsonSerializer.Serialize(response);

                await cxt.Response.WriteAsync(json);
            }
        }
    }
}
