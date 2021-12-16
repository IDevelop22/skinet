using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;

namespace API.Helpers
{
    public class ExceptionHandlingMidleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMidleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await context.Response.WriteAsJsonAsync<ApiServerErrorResponse>(new ApiServerErrorResponse(500,details: ex.Message));
            }
        }
    }
}