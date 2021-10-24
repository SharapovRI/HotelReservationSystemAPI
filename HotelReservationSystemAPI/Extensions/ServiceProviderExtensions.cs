using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Services;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystemAPI.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalFacilityOrderRepository, AdditionalFacilityOrderRepository>();
            services.AddScoped<IAdditionalFacilityRepository, AdditionalFacilityRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomsCostRepository, RoomsCostRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IServiceCostRepository, ServiceCostRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalFacilityService, AdditionalFacilityService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ILocateService, LocateService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();

            return services;
        }
    }
}
