using DeltaplanTask.Data;
using DeltaplanTask.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaplanTask.Middleware
{
    public class AuthenticationAPIKEYClientMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationAPIKEYClientMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthServices service)
        {
            string apikey = context.Request.Headers["API_KEY"];

            if (apikey != null)
            {
                if (service.IsOK(apikey))
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                return;
            }
        }
    }
}
