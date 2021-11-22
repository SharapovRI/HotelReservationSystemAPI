using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystemAPI.Extensions
{
    public static class RepositoriesProvider
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalFacilityOrderRepository, AdditionalFacilityOrderRepository>();
            services.AddScoped<IAdditionalFacilityRepository, AdditionalFacilityRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomsCostRepository, RoomsCostRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IFacilityCostRepository, FacilityCostRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IHotelPhotoRepository, HotelPhotoRepository>();

            return services;
        }
    }
}
