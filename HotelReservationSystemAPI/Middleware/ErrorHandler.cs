using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Exceptions;
using Microsoft.AspNetCore.Http;

namespace HotelReservationSystemAPI.Middleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                switch (error)
                {
                    case NotFound _:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case BadRequest _:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case SomethingWrong _:
                        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    case NoContent _:
                        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                        break;
                    default:
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(error.Message));
            }
        }
    }
}
