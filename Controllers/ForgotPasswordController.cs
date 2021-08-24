using BusBooking.DTO;
using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BusBooking.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        private UserContext db = new UserContext();
        [HttpPost]
        [ResponseType(typeof(ForgotPassword))]

        public IHttpActionResult Postpass(ForgotPassword model)

        {
            IHttpActionResult response = BadRequest("Invalid username/Email");

            User user = db.Users.Where(m => m.Email == model.Email).FirstOrDefault();
            return Ok(user);
        }
    }
}
