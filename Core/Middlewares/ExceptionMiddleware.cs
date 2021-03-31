using Core.Exceptions;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(httpContext, error);
            }
        }


        private async Task HandleExceptionAsync(HttpContext httpContext, Exception error)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new Result();
            response.Success = false;
            response.Errors.Add(error?.Message);

            switch (error)
            {
                //case Application.Exceptions.ApiException e:
                //    // custom application error
                //    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    break;
                case ValidationException e:
                    // custom application error
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Errors = e.Errors;
                    break;
                //case KeyNotFoundException e:
                //    // not found error
                //    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                //    break;
                default:
                    // unhandled error
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(response);
            
            await httpContext.Response.WriteAsync(result);
        }
    }
}
