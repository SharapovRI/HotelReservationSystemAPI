using HotelReservationSystemAPI.Middleware;
using Microsoft.AspNetCore.Builder;

namespace HotelReservationSystemAPI.Extensions
{
    public static class ErrorHandlerProvider
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandler>();
        }
    }
}
