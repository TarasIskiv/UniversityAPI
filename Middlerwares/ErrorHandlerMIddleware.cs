using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UniversityAPI.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //"enableStepFiltering": false
            try
            {
                await next.Invoke(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Something go wrong\n" + ex.Message);
            }
        }
    }
}