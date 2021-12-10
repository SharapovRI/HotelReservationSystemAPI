using HotelReservationSystemAPI.Business.Constants;
using HotelReservationSystemAPI.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystemAPI.Extensions
{
    public static class AuthorizationProvider
    {
        public static IServiceCollection AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(APIPolicies.AdminPolicy, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("Role", APIRoles.Admin);
                });
                opt.AddPolicy(APIPolicies.UserPolicy, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("Role", APIRoles.User);
                });
            });

            return services;
        }
    }
}
