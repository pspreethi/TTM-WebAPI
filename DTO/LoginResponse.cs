using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusBooking.DTO
{
    public class LoginResponse
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}