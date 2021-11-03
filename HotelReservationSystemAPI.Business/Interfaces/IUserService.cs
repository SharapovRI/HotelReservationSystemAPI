﻿using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseModel> AuthenticateAsync(AuthRequestModel model);
        Task<AuthResponseModel> RegistrateAsync(RegistrationModel registrationModelodel);
        Task<AuthResponseModel> RefreshTokenAsync(string token);
    }
}