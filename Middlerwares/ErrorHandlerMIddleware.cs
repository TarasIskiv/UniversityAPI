using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UniversityAPI.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Something go wrong");
            }
        }
    }
}