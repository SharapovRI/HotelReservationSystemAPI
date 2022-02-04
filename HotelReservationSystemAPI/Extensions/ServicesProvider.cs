using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystemAPI.Extensions
{
    public static class ServicesProvider
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalFacilityService, AdditionalFacilityService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ILocateService, LocateService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHotelPhotoService, HotelPhotoService>();
            services.AddScoped<IRoomPhotoService, RoomPhotoService>();

            return services;
        }
    }
}
