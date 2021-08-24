using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusBooking.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Date { get; set; }
        public string Seat { get; set; }
        public int BusID { get; set; }
            
        [ForeignKey("BusID")]
        public virtual Bus Bus { get; set; }
        public string Email { get; set; }
    }
}