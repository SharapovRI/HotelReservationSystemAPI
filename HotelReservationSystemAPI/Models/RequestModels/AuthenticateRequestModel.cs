﻿using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class AuthenticateRequestModel
    {
        [Required(ErrorMessage = "Enter your username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username length must be between 3 and 20 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password length must be between 8 and 50 characters")]
        public string Password { get; set; }
    }
}
