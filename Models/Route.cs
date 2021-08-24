using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusBooking.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}