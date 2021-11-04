using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class OrderPostModel
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        [Remote(action: "CheckTime", controller: "Orders", ErrorMessage = "Date or time is incorrect.")]
        public DateTimeOffset CheckInTime { get; set; }

        [Required]
        [Remote(action: "CheckTime", controller: "Orders", ErrorMessage = "Date or time is incorrect.")]
        public DateTimeOffset CheckOutTime { get; set; }

        [Required]
        [Range(0, 9999, ErrorMessage = "Price must be between 0 and 9999")]
        public decimal Cost { get; set; }

        public int[] AdditionalFacilities { get; set; }
    }
}
