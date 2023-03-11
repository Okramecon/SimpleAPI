using System.Net.Mime;
using System.Net;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Text.Json;

namespace SimpleAPI.Api.Middlwares
{
    public class ExceptionHandlerMiddleware
    {
        public RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var status = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = status;
                var model = new BadRequestModel
                {
                    Status = status,
                    Message = ex.Message.ToString()
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(model));
            }
        }

        public class BadRequestModel
        {
            public int Status { get; set; }
            public string Message { get; set; }
        }
    }
}
