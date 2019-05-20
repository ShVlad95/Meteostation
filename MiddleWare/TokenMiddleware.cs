using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.MiddleWare
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var hasTokenParam = context.Request.Query.ContainsKey("token");

            if (!hasTokenParam)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Bad request. Your query doesn't have token parameter!!!");
                return;
            }


            var token = context.Request.Query["token"];
            
            if (token != "111")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
