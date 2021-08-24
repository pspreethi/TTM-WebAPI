using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusBooking.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public string BusName { get; set; }
        public string Time { get; set; }
        public double Fare { get; set; }
        public int Seats { get; set; }
        public int RouteID { get; set; }

        [ForeignKey("RouteID")]
        public virtual Route Route { get; set; }

    }
}