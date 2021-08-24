using BusBooking.DTO;
using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusBooking.Controllers
{
    public class SeatConfirmController : ApiController
    {
        private UserContext db = new UserContext();
        [HttpPost]
        public IHttpActionResult Post(BookingConfirm model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IHttpActionResult response = BadRequest("Invalid username/password");

            //using (var context = new UserContext())
            //{
            //    if (context.Users.Any(u => u.Email == model.Email && u.Password == model.Password))
            //    {
            //        var result = (from user in context.Users
            //                      where user.Email == model.Email
            //                      select new { user.FirstName, user.Email }).Single();
            //        response = Ok(new LoginResponse { FirstName = result.FirstName, Email = result.Email,Status="Success"});
            //    }
            //}
            //return response;
            Booking booking = db.Bookings.Where(m => m.BusID == model.BusID && m.Seat == model.Seat).FirstOrDefault();
            if(booking!=null)
            {
                return Ok(booking.BookingID);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
