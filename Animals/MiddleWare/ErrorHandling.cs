using Animals.DataAccess;
using Animals.Models;
using Animals.ResultMessages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.MiddleWare
{
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandling> _logger;
        public ErrorHandling(RequestDelegate next, ILogger<ErrorHandling> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, AnimalsDbContext trDbContext)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger, trDbContext);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandling> logger, AnimalsDbContext _trDbContext)
        {
            object errors = null;
            string source = null;

            switch (ex)
            {
                case RestException re:
                    logger.LogError(ex, "Rest Error");
                    errors = re.Message;
                    source = "Rest Exception";
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    break;

                case Exception e:
                    logger.LogError(ex, "Server Error");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    source = "Server Error";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            if (errors != null)
            {
                var strErrors = JsonConvert.SerializeObject(new
                {
                    errors
                });

                _trDbContext.ErrorLog.Add(new ErrorLog { Message = strErrors, Source = source, StackTrace = ex.StackTrace });
                await _trDbContext.SaveChangesAsync();

                await context.Response.WriteAsync(strErrors);
            }
        }

    }
}
