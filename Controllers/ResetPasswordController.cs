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
    public class ResetPasswordController : ApiController
    {
        private UserContext db = new UserContext();
        [HttpPost]
        [ResponseType(typeof(ResetPassword))]

        public IHttpActionResult Postpass(ResetPassword model)

        {

            IHttpActionResult response = BadRequest("Invalid username/Email");

            User user = db.Users.Where(m => m.Email == model.Email).FirstOrDefault();
            user.Email = model.Email;
            user.Password = model.ConfirmPassword;
            db.SaveChanges();

            return Ok(user);
        }
    }
}

