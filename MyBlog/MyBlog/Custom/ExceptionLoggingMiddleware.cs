using Microsoft.AspNetCore.Http;
using MyBlog.Common.Models;
using MyBlog.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Custom
{
    public class ExceptionLoggingMiddleware
    {
        private RequestDelegate _next;
        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogService logService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var logData = new LogData() { Type = LogType.Error, DateCreated = DateTime.Now, Message = ex.ToString() };
                logService.Log(logData);

                throw;
            }
        }

    }
}
