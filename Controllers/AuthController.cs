using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusBooking.Models;
using BusBooking.DTO;

namespace BusBooking.Controllers
{
    public class AuthController : ApiController
    {
        private UserContext db = new UserContext();
        [HttpPost]
        [ResponseType(typeof(LoginResponse))]
        public IHttpActionResult Post( LoginRequest model)
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
            User user = db.Users.Where(m => m.Email == model.Email && m.Password == model.Password).FirstOrDefault();
            return Ok(user);
        }
    }
}
