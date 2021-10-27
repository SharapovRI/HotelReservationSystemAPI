﻿namespace HotelReservationSystemAPI.Business.Validation
{
    public class OrderValidationParameters
    {
        public bool IsDateValid { get; set; } = false;
        public bool IsFacilitiesValid { get; set; } = false;
        public bool IsCostValid { get; set; } = false;

        public bool IsValid => IsDateValid && IsFacilitiesValid && IsCostValid;
    }
}
