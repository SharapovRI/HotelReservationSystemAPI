using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystemAPI.Business.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddBusinessMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceProviderExtensions));

            return services;
        }
    }
}
