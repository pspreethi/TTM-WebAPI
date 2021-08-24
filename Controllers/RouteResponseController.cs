using BusBooking.DTO;
using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BusBooking.Controllers
{
    public class RouteResponseController : ApiController
    {
        private UserContext db = new UserContext();
        [HttpPost]
        [ResponseType(typeof(RouteResponse))]
        public IHttpActionResult Post(RouteRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IHttpActionResult response = BadRequest("Invalid Sources");

            //using (var context = new UserContext())
            //{
            //    if (context.Routes.Any(u => u.Start == model.Start && u.End == model.End))
            //    {
            //        var result = (from route in context.Routes
            //                      where route.Start == model.Start && route.End = model.End
            //                      select new { user.FirstName, user.Email }).Single();
            //        response = Ok(new LoginResponse { FirstName = result.FirstName, Email = result.Email, Status = "Success" });
            //    }
            //}
            //return response;
            Route route = db.Routes.Where(m => m.Start == model.Start && m.End == model.End).FirstOrDefault();
            if (route != null)
            {
                return Ok(route.RouteID);
            }
            else
                return BadRequest();
                
        }
        //public Bus[] GetBusbyRoute(int Routeid)
        //{
        //    //Bus bus = db.Buses.FirstOrDefault(m => m.RouteID.ToString().Contains(Routeid)).ToList();
        //    var query = from a in db.Buses select a;
        //    query.Where(a => a.RouteID.Contains(Routeid));
        //    Bus[] buses = query.ToArray<Bus>();

        //    return buses;


        //}
        public HttpResponseMessage Get(int routeid)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            using (UserContext Context = new UserContext())
            {
                var buses = Context.Buses.SqlQuery("SELECT * FROM dbo.Buses WHERE RouteID = @routeid", new SqlParameter("@routeid", routeid)).ToList();
                //return Ok(buses);
                return Request.CreateResponse(HttpStatusCode.OK, buses);

                
                
            }
        }

    }
}
