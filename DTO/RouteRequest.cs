using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusBooking.DTO
{
    public class RouteRequest
    {
        [Required]
        public string Start { get; set; }

        [Required]
        public string End { get; set; }
    }
}